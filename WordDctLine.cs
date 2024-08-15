// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



using System;



// namespace



public class WordDctLine
{
private MainData mData;
private Word[] valueArray;
private int arrayLast = 0;



private WordDctLine()
{
}



internal WordDctLine( MainData useMainData )
{
mData = useMainData;

try
{
valueArray = new Word[1];

// An array of structs would get initialized,
// but not an array of objects.
valueArray[0] = new Word( mData );
}
catch( Exception Except )
  {
  freeAll();
  mData.showStatus(
     "Not enough memory for WordDctLine." );
  mData.showStatus( Except.Message );
  // return;
  }
}


internal void freeAll()
{
arrayLast = 0;
resizeArrays( 1 );
}



internal int getArrayLast()
{
return arrayLast;
}



internal void clear()
{
arrayLast = 0;
}



void resizeArrays( int newSize )
{
int oldSize = valueArray.Length;

try
{
Array.Resize( ref valueArray, newSize );

if( newSize > oldSize )
  {
  for( int count = oldSize; count < newSize;
                                    count++ )
    {
    // An array of structs would get initialized,
    // but not an array of objects.
    valueArray[count] = new
                     Word( mData );
    }
  }
}
catch( Exception ) // Except )
  {
  freeAll();
  throw new Exception(
         "Not enough memory for WordDctLine." );

  }
}



/*
private int getIndexOfUrl( string url )
{
if( arrayLast < 1 )
  return -1;

int max = arrayLast;
for( int count = 0; count < max; count++ )
  {
  if( valueArray[count].urlIsEqual( url ))
    return count;

  }

return -1;
}



internal bool keyExists( string url )
{
if( getIndexOfUrl( url ) < 0 )
  return false;

return true;
}




internal void setValue( Story value )
{
// This sets the Story to the new value
// whether it's already there or not.

string url = value.getUrl();

int index = getIndexOfUrl( url );
if( index >= 0 )
  {
  valueArray[index].copy( value );
  }
else
  {
  int arraySize = valueArray.Length;
  if( arrayLast >= arraySize )
    resizeArrays( arraySize + 16 );

  valueArray[arrayLast].copy( value );
  arrayLast++;
  }
}




internal void getValue( string url,
                        Story story )
{
story.clear();
int index = getIndexOfUrl( url );
if( index < 0 )
  return;

story.copy( valueArray[index] );
}




internal void getCopyStoryAt( Story story,
                              int where )
{
story.clear();

if( where < 0 )
  return;

if( where >= arrayLast )
  return;

story.copy( valueArray[where] );
}
*/




} // Class
