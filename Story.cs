// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class Story
{
private MainData mData;
private string linkText = "";
private TimeEC linkDate;
private string urlFrom = "";
private StrAr paraAr;
// DateTime when it was downloaded.



private Story()
{
}




internal Story( MainData mDataToUse,
                string useURL,
                ulong dateIndex,
                string useLinkText )
{
mData = mDataToUse;
urlFrom = useURL;
linkDate = new TimeEC( dateIndex );
linkText = Str.cleanAscii( useLinkText );
linkText = Str.trim( linkText );
paraAr = new StrAr();
}



internal void appendParaG( string para )
{
paraAr.append( para );
}


internal int getParaLast()
{
return paraAr.getLast();
}



internal void showStory()
{
mData.showStatus( " " );
mData.showStatus( "showStory()" );
mData.showStatus( "Link date: " +
                  linkDate.toLocalDateString());
mData.showStatus( "Link Text: " + linkText );
mData.showStatus( "URL: " + urlFrom );
mData.showStatus( " " );

int last = paraAr.getLast();
for( int count = 0; count < last; count++ )
  {
  mData.showStatus( paraAr.getStrAt( count ));
  mData.showStatus( " " );
  }

mData.showStatus( " " );
}




internal string toString()
{
string result = urlFrom +
                MarkersAI.StoryDelim +
                linkDate.toDelimStr() +
                MarkersAI.StoryDelim +
                linkText +
                MarkersAI.StoryDelim;

string paraGraphs = "";
int last = paraAr.getLast();
for( int count = 0; count < last; count++ )
  {
  paraGraphs += paraAr.getStrAt( count ) +
                MarkersAI.StoryParagDelim;
  }

result += paraGraphs + MarkersAI.StoryDelim;
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
paraAr.clear();
}



internal void copy( Story toCopy )
{
linkDate.copy( toCopy.linkDate );
urlFrom = toCopy.urlFrom;
linkText = toCopy.linkText;
paraAr.copy( toCopy.paraAr );
}




} // Class
