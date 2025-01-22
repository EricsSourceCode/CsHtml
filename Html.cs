// Copyright Eric Chauvin 2024 - 2025.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class Html
{
private MainData mData;
private string fileName = "";
private string fileS = "";
private TimeEC linkDate;
private string linkText = "";
// Where this HTML file came from:
private string fromUrl = "";
// private Paragraph paragraph;
private UrlParse urlParse;
private string markedUpS = "";
private string htmlS = "";
private string javaS = "";
private string cDataS = "";
// private string styleS = "";
// private string linkS = "";
private TagSplit lastTagSpl;



private Html()
{
}


public Html( MainData useMData,
             string useUrl,
             string fileNameToUse,
             ulong linkDateIndex,
             string linkTextToUse )
{
mData = useMData;
fromUrl = useUrl;
urlParse = new UrlParse( mData, fromUrl );
// paragraph = new Paragraph( mData, fromUrl );
fileName = fileNameToUse;
linkDate = new TimeEC( linkDateIndex );
linkText = linkTextToUse;
lastTagSpl = new TagSplit( mData );
}




internal void readFileS()
{
if( fileName.Length == 0 )
  return;

// mData.showStatus( " " );
// mData.showStatus( "Reading: " + fileName );
// mData.showStatus( "Came from URL " + fromUrl );

if( !SysIO.fileExists( fileName ))
  {
  mData.showStatus( "Does not exist: " +
                                 fileName );
  return;
  }

fileS = SysIO.readAllText( fileName );
fileS = MarkersAI.removeAllMarkers( fileS );

if( fileS.Length < 2 )
  {
  mData.showStatus( "File length zero." );
  return;
  }
}




internal void markupSections()
{
SBuilder scrBuild = new SBuilder();
SBuilder htmlBuild = new SBuilder();
SBuilder javaBuild = new SBuilder();
SBuilder cDataBuild = new SBuilder();
// SBuilder styleBuild = new SBuilder();

// CData can be commented out within a script:
// slash star  ]]><![CDATA[  star slash.
// It is to make it so it's not interpreted.
// But it's within a script.
// And then the script interprets the CData
// begin and end markers as something within
// star slash comments.  To be ignored.

// You could also have // -->
// Two slashes for comments, which comment out
// the ending --> comment marker.
// Or a script tag followed by: <!--

// There are no parameters on ending tags
// like this: </a>.

// Replacing things in the right order here.

string result = fileS;
result = Str.replace( result, "<![CDATA[",
               "" + MarkersAI.BeginCData );

result = Str.replace( result, "]]>",
               "" + MarkersAI.EndCData );

result = Str.replace( result, "<script",
               "" + MarkersAI.BeginScript );

result = Str.replace( result, "</script>",
               "" + MarkersAI.EndScript );

result = Str.replace( result, "<!--",
               "" + MarkersAI.BeginHtmlComment );

result = Str.replace( result, "-->",
               "" + MarkersAI.EndHtmlComment );

result = Str.replace( result, "<style",
               "" + MarkersAI.StyleTagStart );

result = Str.replace( result, "</style>",
               "" + MarkersAI.StyleTagEnd );



bool isInsideCData = false;
bool isInsideScript = false;
bool isInsideHtmlComment = false;
bool isInsideStyleTag = false;

int last = result.Length;
for( int count = 0; count < last; count++ )
  {
  char testC = Str.charAt( result, count );

  if( testC == MarkersAI.BeginCData )
    {
    if( isInsideScript )
      {
      mData.showStatus(
          "Start CData inside script." );
      }

    isInsideCData = true;
    continue;
    }

  if( testC == MarkersAI.EndCData )
    {
    isInsideCData = false;
    continue;
    }

  if( testC == MarkersAI.StyleTagStart )
    {
    isInsideStyleTag = true;
    continue;
    }

  if( testC == MarkersAI.StyleTagEnd )
    {
    isInsideStyleTag = false;
    continue;
    }

  if( testC == MarkersAI.BeginScript )
    {
    if( isInsideHtmlComment )
      {
      mData.showStatus(
            "Script starts inside comment." );

      }

    isInsideScript = true;
    continue;
    }

  if( testC == MarkersAI.EndScript )
    {
    isInsideScript = false;
    continue;
    }

  if( testC == MarkersAI.BeginHtmlComment )
    {
    isInsideHtmlComment = true;
    continue;
    }

  if( testC == MarkersAI.EndHtmlComment )
    {
    isInsideHtmlComment = false;
    continue;
    }

  if( isInsideScript )
    {
    javaBuild.appendChar( testC );
    }

  if( isInsideCData )
    {
    cDataBuild.appendChar( testC );
    }

  if( !(isInsideCData ||
        isInsideScript ||
        isInsideHtmlComment ||
        isInsideStyleTag ))
    {
    htmlBuild.appendChar( testC );
    }
  }

htmlS = htmlBuild.toString();

// Don't cleanAscii() for the Markers here.

markedUpS = result;

// mData.showStatus( " " );
// mData.showStatus( "htmlS:" );
// mData.showStatus( htmlS );

// mData.showStatus( " " );
// mData.showStatus( "markedUpS:" );
// mData.showStatus( markedUpS );

javaS = javaBuild.toString();
cDataS = cDataBuild.toString();

// mData.showStatus( " " );
// mData.showStatus( "javaS:" );
// mData.showStatus( javaS );

// mData.showStatus( " " );
// mData.showStatus( "cData:" );
// mData.showStatus( cDataS );
}



internal bool makeWebPage( WebPage webPage ) // ,
                         // WordDct paragDct )
{
// SBuilder htmlBuild = new SBuilder();
SBuilder tagBuild = new SBuilder();
SBuilder nonTagBuild = new SBuilder();

bool isInsideTag = false;

int last = htmlS.Length;
for( int count = 0; count < last; count++ )
  {
  if( (count % 2000) == 0 )
    {
    if( !mData.checkEvents())
      return false;

    }

  char testC = Str.charAt( htmlS, count );

  if( testC == '<' )
    {
    if( isInsideTag )
      {
      mData.showStatus( " " );
      mData.showStatus(
                   "< Already inside tag." );
      string showLinkTag = tagBuild.toString();
      // Don't clear tagBuild here.
      mData.showStatus( showLinkTag );
      mData.showStatus( " " );
      continue; // Ignore this in a Link tag.
      }

    isInsideTag = true;
    tagBuild.clear();
    tagBuild.appendChar( '<' );

    addNonTagText( webPage, nonTagBuild ); // ,
                   // paragDct );
    continue;
    }

  if( testC == '>' )
    {
    if( !isInsideTag )
      {
      mData.showStatus( " " );
      mData.showStatus(
                   "Not already inside tag." );

      // Not clearing this here (?)
      string showText = nonTagBuild.toString();

      mData.showStatus( showText );
      mData.showStatus( " " );
      continue; // Ignore it here.
      }

    tagBuild.appendChar( '>' );
    lastTagSpl.setTagText( 
                    tagBuild.toString() );

    // The text of the anchor tag is already
    // non tag text.  It is after the anchor
    // start tag.
    // if( Str.startsWith( showTag, "<a " ))
      // mData.showStatus( "<a>" );

    tagBuild.clear();
    isInsideTag = false;
    continue;
    }

  if( isInsideTag )
    tagBuild.appendChar( testC );
  else
    nonTagBuild.appendChar( testC );

  }

return true;
}



private void addNonTagText( WebPage webPage,
                         SBuilder nonTagBuild )
                         // ,
                         // WordDct paragDct )
{
if( !lastTagSpl.isTagToShow())
  {
  nonTagBuild.clear();
  return;
  }
// A paragraph or heading or something that
// is not inside any tags.

string para = nonTagBuild.toString();
nonTagBuild.clear();

para = Str.trim( para );
if( para.Length < 1 )
  return;

// mData.showStatus( " " );
// mData.showStatus( "addNonTagText()" );

para = Ampersand.fixChars( para );
// para = NonAscii.fixIt( para );
// showNonAscii( para );
para = Str.replace( para, "\r", " " );
para = Str.replace( para, "\n", " " );
// para = Str.cleanAscii( para );

// mData.showStatus( " " );
// mData.showStatus( "addNonTagText()" );

// Trim it again.
para = Str.trim( para );
if( para.Length == 0 )
  return;

// if( !GoodParag.isGoodParag( para ))
//  return;

string showText = lastTagSpl.getTagText() +
                         "\r\n" + para;
mData.showStatus( " " );
mData.showStatus( showText );

// if( !paragDct.keyExists( para ))
  webPage.appendParaG( para );

// Add the count if it already exists.
// paragDct.addWord( para );
}




private void showNonAscii( string toCheck )
{
int max = toCheck.Length;
for( int count = 0; count < max; count++ )
  {
  char c = toCheck[count];
  if( (c > 127) ) // || (c < ' ') )
    {
    int showC = c;
    mData.showStatus( "showC: " + showC + ") " +
                                 c );
    }
  }
}




} // Class
