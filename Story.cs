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
linkText = useLinkText;
paraAr = new StrAr();
}



internal void appendParaG( string para )
{
paraAr.append( para );
}



internal void showStory()
{
mData.showStatus( " " );
mData.showStatus( "showStory()" );
mData.showStatus( "Link date: " +
                  linkDate.toLocalDateString());
mData.showStatus( "Link Text: " + linkText );
mData.showStatus( " " );

int last = paraAr.getLast();
for( int count = 0; count < last; count++ )
  {
  mData.showStatus( paraAr.getStrAt( count ));
  mData.showStatus( " " );
  }

mData.showStatus( " " );
}





} // Class
