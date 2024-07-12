// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace


public class HtmlFile
{
private MainData mData;
private string fileName = "";
private string fileS = "";

// Where this HTML file came from:
private string fromUrl = "";
private Paragraph paragraph;
private UrlParse urlParse;
private string markedUpS = "";
private string htmlS = "";
private string javaS = "";
private string cDataS = "";



private HtmlFile()
{
}


public HtmlFile( MainData useMData,
                 string useUrl,
                 string fileNameToUse )
{
mData = useMData;
fromUrl = useUrl;
urlParse = new UrlParse( mData, fromUrl );
paragraph = new Paragraph( mData, fromUrl );
fileName = fileNameToUse;
}




internal void readFileS()
{
if( fileName.Length == 0 )
  return;

mData.showStatus( " " );
mData.showStatus( "Reading: " + fileName );
mData.showStatus( "Came from URL " + fromUrl );

if( !SysIO.fileExists( fileName ))
  {
  mData.showStatus( "Does not exist: " +
                                 fileName );
  return;
  }

fileS = SysIO.readAllText( fileName );

if( fileS.Length < 2 )
  {
  mData.showStatus( "File length zero." );
  return;
  }
}


/*
internal void processAnchorTags()
{
mData.showStatus( "processAnchorTags()" );

bool isInsideAnchor = false;

urlParse.clear();

// The link tag is for style sheets.

StrAr tagParts = new StrAr();
tagParts.split( htmlS, '<' );
int last = tagParts.getLast();

// string beforeFirst = tagParts.getStrAt( 0 );
// mData.showStatus( "Before first: " +
//                              beforeFirst );

for( int count = 1; count < last; count++ )
  {
  string line = tagParts.getStrAt( count );

  string lowerLine = Str.toLower( line );
  if( !( Str.startsWith( lowerLine,
                           tagAnchorStart ) ||
         Str.startsWith( lowerLine,
                           tagAnchorEnd ) ))
    continue;

  StrAr lineParts = new StrAr();
  lineParts.split( line, '>' );
  int lastPart = lineParts.getLast();
  if( lastPart == 0 )
    {
    mData.showStatus(
           "The tag doesn't have any parts." );
    mData.showStatus( "line: " + line );
    return;
    }

  if( lastPart > 2 )
    {
    // line: /span> Posting">Post comment
    // mApp.showStatusAsync( "lastPart > 2." );
    // mApp.showStatusAsync( "line: " + line );
    continue;
    }

  string tag = lineParts.getStrAt( 0 );
  // It's a short tag that I don't want to
  // deal with yet.
  if( Str.endsWith( tag, "/" ))
    {
    // if( tag.startsWithChar( 'a' ))
    // mApp.showStatusAsync( "Short tag: " + tag );
    continue;
    }

  StrAr tagAttr = new StrAr();
  tagAttr.split( tag, ' ' );
  int lastAttr = tagAttr.getLast();
  if( lastAttr == 0 )
    {
    mData.showStatus(
              "lastAttr is zero for the tag." );
    mData.showStatus( "tag: " + tag );
    return;
    }

  string tagName = tagAttr.getStrAt( 0 );
  tagName = Str.toLower( tagName );

  // mData.showStatus( "tagName: " + tagName );

  if( tagName == tagAnchorStart )
    {
    isInsideAnchor = true;
    urlParse.clear();

    for( int countA = 1; countA < lastAttr;
                                    countA++ )
      {
      string attr = tagAttr.getStrAt( countA );
      attr = attr += " ";
      urlParse.addRawText( attr );
      }

    urlParse.addRawText( " >" );
    }

  if( tagName == tagAnchorEnd )
    {
    if( urlParse.processLink())
      {
      string link = urlParse.getLink();
      string linkText = urlParse.getLinkText();
      if( linkText.Length > 0 )
        {
        mData.showStatus( "After UrlParse:" );
        mData.showStatus( "LinkText: "
                                 + linkText );
        mData.showStatus( "Link: " + link );
        // URLFile uFile = new URLFile( mApp,
        //                   linkText, link );
        // urlFileDictionary.setValue(
        //      link, uFile );
        }
      }
    }

  if( isInsideAnchor )
    {
    if( lastPart >= 2 )
      {
      urlParse.addRawText(
                    lineParts.getStrAt( 1 ));
      }
    }
  }
}
*/



internal void makeStory( Story story )
{
mData.showStatus( " " );
mData.showStatus( "makeStory()" );

StrAr tagParts = new StrAr();
tagParts.split( htmlS,
                  MarkersAI.BeginParagraphTag );
int last = tagParts.getLast();
// mData.showStatus( "tagParts last: " + last );


// string beforeFirst = tagParts.getStrAt( 0 );
// mData.showStatus( "Before first: " +
//                              beforeFirst );

for( int count = 1; count < last; count++ )
  {
  string line = tagParts.getStrAt( count );
  // mData.showStatus( "line: " + line );

  StrAr paraParts = new StrAr();
  paraParts.split( line,
                   MarkersAI.EndParagraphTag );

  int lastPara = paraParts.getLast();
  if( lastPara < 1 )
    continue;

  string para = paraParts.getStrAt( 0 );

  if( Str.contains( para,
                  "class=\"copyright\"" ) ||
    Str.contains( para,
               "class=\"subscribed hide\"" ) ||
    Str.contains( para,
               "class=\"success hide\"" ) ||
    Str.contains( para,
               "class=\"dek\"" ))
    continue;

  // Looking for the end of the parameter
  // for the P tag.
  // if( !Str.contains( para, ">" ))
    // continue;

  para = Str.removeUpToC( para, '>' );

  // mData.showStatus( " " );
  // mData.showStatus( "para: " + para );

  para = fixAnchorText( para );
  para = fixSpanText( para );

  para = Str.replace( para, "<strong>", "" );
  para = Str.replace( para, "</strong>", "" );
  para = Str.replace( para, "<span>", "" );
  para = Str.replace( para, "</span>", "" );
  para = Str.replace( para, " ,", "," );

  para = Str.trim( para );

  string paraLow = Str.toLower( para );
  if( Str.contains( paraLow, "biden" ))
    {
    mData.showStatus( " " );
    mData.showStatus( para );
    }

  story.appendParaG( para );
  }
}




private string fixSpanText( string inS )
{
if( !Str.contains( inS,
               "" + MarkersAI.BeginSpanTag ))
  return inS;

StrAr paraParts = new StrAr();
paraParts.split( inS, MarkersAI.BeginSpanTag );
int lastPara = paraParts.getLast();

// if( lastPara < 2 )
  // return inS;

string result = paraParts.getStrAt( 0 ) + " ";

for( int count = 1; count < lastPara; count++ )
  {
  string spanPart =
              paraParts.getStrAt( count );

  spanPart = Str.removeUpToC( spanPart, '>' );
  result += spanPart;
  }

result = Str.replace( result, "  ", " " );
return result;
}




private string fixAnchorText( string inS )
{
if( !Str.contains( inS,
               "" + MarkersAI.BeginAnchorTag ))
  return inS;

StrAr paraParts = new StrAr();
paraParts.split( inS, MarkersAI.BeginAnchorTag );
int lastPara = paraParts.getLast();

// if( lastPara < 2 )
  // return inS;

string result = paraParts.getStrAt( 0 ) + " ";

for( int count = 1; count < lastPara; count++ )
  {
  string anchorPart =
              paraParts.getStrAt( count );

  if( !Str.contains( anchorPart,
                  "" + MarkersAI.EndAnchorTag ))
    {
    return "No ending anchor match.";
    // result += anchorPart;
    // break;
    }

  StrAr anchorLines = new StrAr();
  anchorLines.split( anchorPart,
                     MarkersAI.EndAnchorTag );
  int lastAnchor = anchorLines.getLast();
  if( lastAnchor < 2 )
    return "lastAnchor < 2";

  string hrefPart = anchorLines.getStrAt( 0 );
  string textPart = anchorLines.getStrAt( 1 );
  // mData.showStatus( " " );
  // mData.showStatus( "hrefPart: " + hrefPart );

  StrAr hrefLines = new StrAr();
  hrefLines.split( hrefPart, '>' );
  int lastHref = hrefLines.getLast();
  if( lastHref < 2 )
    return "lastHref < 2";

  string hrefText = hrefLines.getStrAt( 1 );
  // mData.showStatus( " " );
  // mData.showStatus( "hrefText: " + hrefText );

  result += hrefText + " " + textPart;
  }

result = Str.replace( result, "  ", " " );
return result;
}




internal void markupSections()
{
SBuilder scrBuild = new SBuilder();
SBuilder htmlBuild = new SBuilder();
SBuilder javaBuild = new SBuilder();
SBuilder cDataBuild = new SBuilder();

// CData can be commented out within a script:
// slash star  ]]><![CDATA[  star slash.
// It is to make it so it's not interpreted
// as HTML.  But it's within a script.
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
            "\r\n\r\n\r\n" + MarkersAI.EndCData );

result = Str.replace( result, "<script",
               "" + MarkersAI.BeginScript );

result = Str.replace( result, "</script>",
        "\r\n\r\n\r\n" + MarkersAI.EndScript );

result = Str.replace( result, "<!--",
               "" + MarkersAI.BeginHtmlComment );

result = Str.replace( result, "-->",
     "\r\n\r\n\r\n" + MarkersAI.EndHtmlComment );

result = Str.replace( result, "<p>", "<p >" );

// Don't want the <picture> tag.
result = Str.replace( result, "<p ",
           "" + MarkersAI.BeginParagraphTag );

result = Str.replace( result, "</p>",
           "" + MarkersAI.EndParagraphTag );

result = Str.replace( result, "<a ",
            "" + MarkersAI.BeginAnchorTag );

result = Str.replace( result, "</a>",
             "" + MarkersAI.EndAnchorTag );

result = Str.replace( result, "<span ",
             "" + MarkersAI.BeginSpanTag );

// In case it is upper case.
result = Str.replace( result, "<P ",
           "" + MarkersAI.BeginParagraphTag );

result = Str.replace( result, "</P>",
           "" + MarkersAI.EndParagraphTag );

result = Str.replace( result, "<A ",
           "" + MarkersAI.BeginAnchorTag );

result = Str.replace( result, "</A>",
           "" + MarkersAI.EndAnchorTag );


bool isInsideCData = false;
bool isInsideScript = false;
bool isInsideHtmlComment = false;

int last = result.Length;
for( int count = 0; count < last; count++ )
  {
  char testC = Str.charAt( result, count );

  // if( isInsideScript )
    // {

  if( testC == MarkersAI.BeginCData )
    {
    isInsideCData = true;
    continue;
    }

  if( testC == MarkersAI.EndCData )
    {
    isInsideCData = false;
    continue;
    }

  if( testC == MarkersAI.BeginScript )
    {
    // if( isInsideCData )
    isInsideScript = true;
    continue;
    }

  if( testC == MarkersAI.EndScript )
    {
    // if( isInsideCData )
    isInsideScript = false;
    continue;
    }

  if( testC == MarkersAI.BeginHtmlComment )
    {
    // if( isInsideCData )
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
        isInsideHtmlComment ))
    {
    htmlBuild.appendChar( testC );
    }
  }

htmlS = htmlBuild.toString();
htmlS = Str.replace( htmlS, "\r", " " );
htmlS = Str.replace( htmlS, "\n", " " );
htmlS = Ampersand.fixChars( htmlS );

// Don't cleanAscii() for the Markers.

markedUpS = result;

// mData.showStatus( " " );
// mData.showStatus( "htmlS:" );
// mData.showStatus( htmlS );

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



} // Class
