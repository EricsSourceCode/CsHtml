// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class Word
{
private MainData mData;
private string wordS = "";
private int index = -1;
private int count = 0;



private Word()
{
}



internal Word( MainData mDataToUse )
{
mData = mDataToUse;
}



/*
internal bool setFromString( string inS )
{
StrAr parts = new StrAr();
parts.split( inS, MarkersAI.StoryDelim );
int last = parts.getLast();

if( last < 4 )
  {
  // mData.showStatus(
  //         "Story: Not enough fields." );
  return false;
  }

urlFrom = parts.getStrAt( 0 );
linkDate.setFromDelim( parts.getStrAt( 1 ));
linkText = parts.getStrAt( 2 );
parags = parts.getStrAt( 3 );
return true;
}



internal string toString()
{
string result = urlFrom +
                MarkersAI.StoryDelim +
                linkDate.toDelimStr() +
                MarkersAI.StoryDelim +
                linkText +
                MarkersAI.StoryDelim +
                parags +
                MarkersAI.StoryDelim;

return result;
}



internal void copy( Story toCopy )
{
linkDate.copy( toCopy.linkDate );
urlFrom = toCopy.urlFrom;
linkText = toCopy.linkText;
parags = toCopy.parags;
}
*/



} // Class
