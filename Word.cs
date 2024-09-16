// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace


// A word or a sequence of words like a
// sentence or paragraph.


public class Word
{
private MainData mData;
private string word = "";
private int idNum = 0;
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
idNum = MathF.strToInt( parts.getStrAt( 1 ),
                        0 );
count = MathF.strToInt( parts.getStrAt( 2 ),
                        0 );

return true;
}



internal string toString()
{
string result = word +
                MarkersAI.WordDelim +
                idNum +
                MarkersAI.WordDelim +
                count +
                MarkersAI.WordDelim;

return result;
}




internal void copy( Word toCopy )
{
word = toCopy.word;
idNum = toCopy.idNum;
count = toCopy.count;
}



internal void clear()
{
word = "";
idNum = 0;
count = 0;
}



internal void setIdNum( int setTo )
{
idNum = setTo;
}



internal int getIdNum()
{
return idNum;
}



internal void incCount()
{
count++;
}


internal void setCount( int setTo )
{
count = setTo;
}


internal int getCount()
{
return count;
}



} // Class



