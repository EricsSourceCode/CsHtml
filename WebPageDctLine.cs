// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



using System;



// namespace



public class WebPageDctLine
{
private MainData mData;
private WebPage[] valueArray;
private int arrayLast = 0;



private WebPageDctLine()
{
}



internal WebPageDctLine( MainData useMainData )
{
mData = useMainData;

try
{
valueArray = new WebPage[1];

// An array of structs would get initialized,
// but not an array of objects.
valueArray[0] = new WebPage( mData, "", 0, "" );
}
catch( Exception Except )
  {
  freeAll();
  mData.showStatus(
     "Not enough memory for WebPageDctLine." );
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
                   WebPage( mData, "", 0, "" );
    }
  }
}
catch( Exception ) // Except )
  {
  freeAll();
  throw new Exception(
      "Not enough memory for WebPageDctLine." );

  }
}



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




internal void setValue( WebPage value )
{
// This sets the WebPage to the new value
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
                        WebPage webPage )
{
webPage.clear();
int index = getIndexOfUrl( url );
if( index < 0 )
  return;

webPage.copy( valueArray[index] );
}




internal void getCopyWebPageAt( WebPage webPage,
                                int where )
{
webPage.clear();

if( where < 0 )
  return;

if( where >= arrayLast )
  return;

webPage.copy( valueArray[where] );
}



/*
internal void showDateAt( int where )
{
if( where < 0 )
  return;

if( where >= arrayLast )
  return;

valueArray[where].showDateTime();
}
*/



/*
====
// Java:

  public StrA makeKeysValuesStrA()
    {
    if( arrayLast < 1 )
      return StrA.Empty;

    StrABld sBld = new StrABld( 1024 * 8 );

    for( int count = 0; count < arrayLast; count++ )
      {
      StrA line = valueArray[count].toStrA();
      sBld.appendStrA( line );
      sBld.appendChar( '\n' );
      }

    return sBld.toStrA();
    }



  public StrA makeFilesStrA()
    {
    if( arrayLast < 1 )
      return StrA.Empty;

    StrABld sBld = new StrABld( 1024 * 8 );

    for( int count = 0; count < arrayLast; count++ )
      {
      StrA line = valueArray[count].getFileName();
      sBld.appendStrA( line );
      sBld.appendChar( '\n' );
      }

    return sBld.toStrA();
    }



  }
*/


} // Class
