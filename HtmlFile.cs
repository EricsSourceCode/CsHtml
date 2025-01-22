/*
This is an old one.
Delete this?


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



private HtmlFile()
{
}


public HtmlFile( MainData useMData,
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




///////////
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
////////////



internal bool makeStory( Story story )
{
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

  // Looking for the end of the parameter
  // for the P tag.
  // if( !Str.contains( para, ">" ))
    // continue;

  para = Str.removeUpToC( para, '>' );

  // mData.showStatus( " " );
  // mData.showStatus( "para: " + para );

  // mData.showStatus( " " );
  // mData.showStatus( "para: " + para );

  para = fixAnchorText( para );

  // mData.showStatus( " " );
  // mData.showStatus( "After anchors: " + para );

  para = fixSpanText( para );

  para = Str.replace( para, "<strong>", "" );
  para = Str.replace( para, "<strong", "" );
  para = Str.replace( para, "</strong>", "" );
  para = Str.replace( para, "</span>", "" );
  para = Str.replace( para, "<em>", "" );
  para = Str.replace( para, "</em>", "" );
  para = Str.replace( para, "<i>", "" );
  para = Str.replace( para, "</i>", "" );

  para = Str.replace( para, "<i", "" );

  para = Str.replace( para, "<b>", "" );
  para = Str.replace( para, "</b>", "" );
  para = Str.replace( para, "<br>", "" );
  para = Str.replace( para, "<u>", "" );
  para = Str.replace( para, "< u>", "" );

  para = Str.replace( para, " ,", "," );
  para = Str.replace( para, "\r", " " );
  para = Str.replace( para, "\n", " " );
  para = Str.replace( para, "\t", " " );

  para = Str.replace( para, "/", " " );

  para = Ampersand.fixChars( para );

  para = fixNonAscii( para );
  showNonAscii( para );

  para = Str.cleanAscii( para );

  para = Str.replace( para, "  ", " " );
  para = Str.replace( para, "  ", " " );
  para = Str.replace( para, "  ", " " );

  para = Str.trim( para );
  if( para.Length == 0 )
    continue;

  if( !GoodParag.isGoodParag( para ))
    continue;

  story.appendParaG( para );
  }

if( story.getParags().Length > 0 )
  return true;

return false;
}




private string fixSpanText( string inS )
{
if( !Str.contains( inS, "<span" ))
  return inS;

string result = inS;

result = Str.replace( result, "<span>",
                              "<span >" );

// It could have a tag like <span >
// or a tag like:
// <span class="video-details__dek-description">

result = Str.replace( result, "<span ",
             "" + MarkersAI.BeginSpanTag );

StrAr spanParts = new StrAr();
spanParts.split( result,
                 MarkersAI.BeginSpanTag );
int lastSpan = spanParts.getLast();

result = spanParts.getStrAt( 0 ) + " ";

for( int count = 1; count < lastSpan; count++ )
  {
  string spanPart =
              spanParts.getStrAt( count );

  spanPart = Str.removeUpToC( spanPart, '>' );
  result += " " + spanPart;
  }

result = Str.replace( result, "  ", " " );
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



private void showNonAscii( string toCheck )
{
int max = toCheck.Length;
for( int count = 0; count < max; count++ )
  {
  char c = toCheck[count];
  if( c > 127 )
    {
    int showC = c;
    mData.showStatus( "showC: " + showC + ") " +
                                 c );
    }
  }
}



private string fixNonAscii( string inS )
{
string result = "";

int max = inS.Length;
for( int count = 0; count < max; count++ )
  {
  char c = inS[count];
  if( c == 160 ) // non breaking space?
    c = ' ';

  if( c == 163 ) // strange character
    continue;
    // c = '#';

  if( c == 167 ) // strange character
    continue;

  if( c == 169 ) // Copyright
    continue;

  if( c == 173 )
    c = '-';

  if( c == 174 ) // Rights symbol
    continue;

  if( c == 176 ) // Little circle
    continue;

  if( c == 177 ) // +- symbol
    continue;

  if( c == 180 ) // apostrophe
    c = '\'';

  if( c == 188 ) // 1/4 symbol
    continue;

  if( c == 189 ) // 1/2 symbol
    continue;

  if( c == 190 ) // 3/4 symbol
    continue;

  if( c == 201 )
    c = 'E';

  if( c == 214 ) // O with two dots.
    c = 'O';

  if( c == 216 ) // O with two dots.
    c = 'O';

  if( c == 224 ) // a with ' mark.
    c = 'a';

  if( c == 225 ) // a with ' mark.
    c = 'a';

  if( c == 226 )
    c = 'a';

  if( c == 227 )
    c = 'a';

  if( c == 229 )
    c = 'a';

  if( c == 231 ) // c with under mark.
    c = 'c';

  if( c == 232 ) // e with ' mark.
    c = 'e';

  if( c == 233 ) // e with ' mark.
    c = 'e';

  if( c == 234 ) // e with hat.
    c = 'e';

  if( c == 235 ) // e two dots.
    c = 'e';

  if( c == 236 )
    c = 'i';

  if( c == 237 ) // i with slanted dot.
    c = 'i';

  if( c == 238 ) // i with hat.
    c = 'i';

  if( c == 239 ) // i with two dots.
    c = 'i';

  if( c == 240 )
    c = 'o';

  if( c == 241 ) // n with tilde.
    c = 'n';

  if( c == 243 ) // o with '.
    c = 'o';

  if( c == 244 )
    c = 'o';

  if( c == 246 )
    c = 'o';

  if( c == 248 ) // Sort of a Phi.
    continue;

  if( c == 249 ) // u with '.
    c = 'u';

  if( c == 250 ) // u with '.
    c = 'u';

  if( c == 251 ) // u with hat.
    c = 'u';

  if( c == 252 ) // u with two dots.
    c = 'u';

  if( c == 263 ) // c with '.
    c = 'c';

  if( c == 268 ) // C with reverse hat.
    c = 'C';

  if( c == 281 )
    c = 'e';

  if( c == 283 ) // e with reverse hat.
    c = 'e';

  if( c == 287 ) // g with reverse hat.
    c = 'g';

  if( c == 333 ) // o with dash on top.
    c = 'o';

  if( c == 347 )
    c = 's';

  if( c == 380 )
    c = 'z';

  if( c == 699 )
    c = '\'';

  if( c == 700 )
    c = '\'';

  if( c == 1057 )
    c = 'C';

  if( c == 1548 )
    continue;

  if( c == 8201 ) // Not showing.
    continue;

  if( c == 8202 ) // Not showing.
    continue;

  if( c == 8203 ) // Not showing.
    continue;

  if( c == 8208 ) // dash or hyphen?
    c = '-';

  if( c == 8211 ) // dash or hyphen?
    c = '-';

  if( c == 8212 ) // dash or hyphen?
    c = '-';

  if( c == 8213 ) // dash or hyphen?
    c = '-';

  if( c == 8216 ) // single quote, apostrophe.
    c = '\'';

  if( c == 8217 ) // single quote, apostrophe.
    c = '\'';

  if( c == 8220 )
    c = '\"';

  if( c == 8221 )
    c = '\"';

  if( c == 8226 ) // a Dot.
    continue;

  if( c == 8230 ) // 3 dots like ...
    continue;

  if( c == 8239 ) // Not showing.
    continue;

  if( c == 8243 )
    c = '\"';

  if( c == 8294 ) // Says LRI.
    continue;

  if( c == 8297 ) // Says PDI.
    continue;

  if( c == 8364 ) // Euroish looking thing?
    continue;

  if( c == 8457 ) // Farenheit degrees.
    c = 'F';

  if( c == 8482 ) // Trademark.
    continue;

  if( c == 8531 ) // 1/3 symbol
    continue;

  if( c == 9654 ) // A triangle symbol
    continue;

  if( c == 9996 ) // Peace hand sign
    continue;


  result += c;
  }

return result;
}



} // Class


*/
