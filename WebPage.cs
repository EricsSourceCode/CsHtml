// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class WebPage
{
private MainData mData;
private string linkText = "";

// The old Java linkdate is when the link was
// found.  Not when the HTML file was
// downloaded.  But it won't read the web page,
// and create the WebPage object, until
// the file is downloaded.

private TimeEC linkDate;

private string urlFrom = "";
private string parags = "";



private WebPage()
{
}



internal WebPage( MainData mDataToUse )
{
mData = mDataToUse;
linkDate = new TimeEC();
}




internal WebPage( MainData mDataToUse,
                string useURL,
                ulong dateIndex,
                string useLinkText )
{
mData = mDataToUse;
urlFrom = useURL;
linkDate = new TimeEC( dateIndex );
linkText = Str.cleanAscii( useLinkText );
linkText = Str.trim( linkText );
}



internal void appendParaG( string para )
{
parags += para + MarkersAI.WebPageParagDelim;
}




internal void showWebPage()
{
mData.showStatus( " " );
mData.showStatus( "showWebPage()" );
mData.showStatus( "Link date: " +
                  linkDate.toLocalDateString());
mData.showStatus( "Link Text: " + linkText );
mData.showStatus( "URL: " + urlFrom );
mData.showStatus( " " );

StrAr paraAr = new StrAr();
paraAr.split( parags,
              MarkersAI.WebPageParagDelim );

int last = paraAr.getLast();
for( int count = 0; count < last; count++ )
  {
  // mData.showStatus( "Paragraph " + count );
  mData.showStatus( paraAr.getStrAt( count ));
  mData.showStatus( " " );
  }

mData.showStatus( " " );
}



internal bool setFromString( string inS )
{
StrAr parts = new StrAr();
parts.split( inS, MarkersAI.WebPageDelim );
int last = parts.getLast();

if( last < 4 )
  {
  // mData.showStatus(
  //         "Story: Not enough fields." );
  return false;
  }

urlFrom = parts.getStrAt( 0 );
linkDate.setFromMarkerDelim(
                         parts.getStrAt( 1 ));
linkText = parts.getStrAt( 2 );
parags = parts.getStrAt( 3 );
return true;
}



internal string toString()
{
string result = urlFrom +
                MarkersAI.WebPageDelim +
                linkDate.toDelimStr() +
                MarkersAI.WebPageDelim +
                linkText +
                MarkersAI.WebPageDelim +
                parags +
                MarkersAI.WebPageDelim;

return result;
}



internal bool urlIsEqual( string toCheck )
{
if( urlFrom == toCheck )
  return true;

return false;
}



internal string getUrl()
{
return urlFrom;
}



internal void clear()
{
linkDate.setToYear1900();
urlFrom = "";
linkText = "";
parags = "";
}



internal void copy( WebPage toCopy )
{
linkDate.copy( toCopy.linkDate );
urlFrom = toCopy.urlFrom;
linkText = toCopy.linkText;
parags = toCopy.parags;
}



internal string getParags()
{
return parags;
}


internal string getParagsVecText()
{
return Str.replace( parags,
                "" + MarkersAI.WebPageParagDelim,
                "\n" );
}



internal ulong getDateIndex()
{
return linkDate.getIndex();
}



internal string getLinkText()
{
return linkText;
}



/*
internal string getWordsLine()
{
string result = Str.replace( parags,
               "" + MarkersAI.StoryParagDelim,
               " " );

result = Str.replace( result,
                      "|",
                      " " );

result = Str.toLower( result );
result = Str.trim( result );
return result;
}
*/


} // Class
