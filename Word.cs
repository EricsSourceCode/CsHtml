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
private string word = "";
private int index = -1;
private int count = 0;



private Word()
{
}



internal Word( MainData mDataToUse,
               string wordS )
{
mData = mDataToUse;
word = wordS;
}



internal string getWord()
{
return word;
}



internal bool setFromString( string inS )
{
clear();

StrAr parts = new StrAr();
parts.split( inS, MarkersAI.WordDelim );
int last = parts.getLast();

if( last < 3 )
  {
  // mData.showStatus(
  //         "Word: Not enough fields." );
  return false;
  }

word = parts.getStrAt( 0 );
index = MathF.strToInt( parts.getStrAt( 1 ),
                        0 );
count = MathF.strToInt( parts.getStrAt( 2 ),
                        0 );

return true;
}



internal string toString()
{
string result = word +
                MarkersAI.WordDelim +
                index +
                MarkersAI.WordDelim +
                count +
                MarkersAI.WordDelim;

return result;
}




internal void copy( Word toCopy )
{
word = toCopy.word;
index = toCopy.index;
count = toCopy.count;
}



internal void clear()
{
word = "";
index = 0;
count = 0;
}



internal void setIndex( int setTo )
{
index = setTo;
}



internal int getIndex()
{
return index;
}




} // Class
