// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



using System;



// namespace



public class StoryDct
{
private MainData mData;
private StoryDctLine[] lineArray;
private const int keySize = 0xFFF;
private ByteBuf resultHash;
private ByteBuf message;


private StoryDct()
{
}



internal StoryDct( MainData useMainData )
{
mData = useMainData;

try
{
lineArray = new StoryDctLine[keySize];
for( int count = 0; count < keySize; count++ )
  lineArray[count] = new StoryDctLine( mData );

resultHash = new ByteBuf();
message = new ByteBuf();

}
catch( Exception Except )
  {
  freeAll();
  mData.showStatus(
     "Not enough memory for StoryDctLines." );
  mData.showStatus( Except.Message );
  // return;
  }
}



internal void freeAll()
{
// lineArray = null;
}



internal void clear()
{
for( int count = 0; count < keySize; count++ )
  lineArray[count].clear();

}



internal int getIndex( string url )
{
if( url.Length == 0 )
  return 0;

message.setFromAsciiStr( url );
mData.sha256.makeHash( resultHash, message );
// string showS = resultHash.getHexStr();
// mData.showStatus( showS );

int index = resultHash.getU8( 0 );
index <<= 8;
index |= resultHash.getU8( 1 );

index = index & keySize;
if( index == keySize )
  index = keySize - 1;

/*
make this distribution thing work right...
  {
  // Distribute those last two at keySize
  // and keySize - 1 more evenly.
  // index = keySize - 1;
  int lastB = message.getLast();
  byte lastByte = message.getU8( lastB - 1 );
  index = index - lastByte;
  }
*/

return index;
}



internal void setValue( string key,
                        Story value )
{
try
{
if( key == null )
  return;

key = Str.toLower( key );
if( key == "" )
  return;

int index = getIndex( key );

lineArray[index].setValue( value );
}
catch( Exception )
  {
  throw new Exception(
       "StoryDct Exception in setValue()." );
  }
}



internal void getValue( string key,
                        Story toGet )
{
toGet.clear();
if( key == null )
  return;

key = Str.toLower( key );
if( key == "" )
  return;

int index = getIndex( key );
if( lineArray[index].getArrayLast() == 0 )
  return;

lineArray[index].getValue( key, toGet );
}



/*

  public boolean keyExists( StrA key )
    {
    if( key == null )
      return false;

    key = key.trim().toLowerCase();
    if( key.length() < 1 )
      return false;

    int index = getIndex( key );
    if( lineArray[index] == null )
      return false;

    return lineArray[index].keyExists( key );
    }



  public void saveToFile()
    {
    StrA fileS = makeKeysValuesStrA();
    FileUtility.writeStrAToFile( mApp,
                                 fileName,
                                 fileS,
                                 false,
                                 true );
    }
*/



internal void readAllFromFile()
{
clear();

string fileName = mData.getStoriesFileName();

mData.showStatus( "Reading file:" );
mData.showStatus( fileName );

if( !SysIO.directoryExists(
                  mData.getDataDirectory()))
  {
  mData.showStatus( "No data directory." );
  return;
  }

string fileS = SysIO.readAllText( fileName );

StrAr lines = new StrAr();
lines.split( fileS, MarkersAI.StoryListDelim );
int last = lines.getLast();

mData.showStatus( "Stories: " + last );

for( int count = 0; count < last; count++ )
  {
  string line = lines.getStrAt( count );
  // line = Str.trim( line );

  Story story = new Story( mData );
  if( !story.setFromString( line ))
    continue;

  string url = story.getUrl();
  int index = getIndex( url );

  // mData.showStatus( "url: " + url );
  // mData.showStatus( "index: " + index );
  // if( count > 50 )
    // break;

  lineArray[index].setValue( story );
  }
}




/*
internal void htmlSearch( string toFindUrl,
                          string toFind,
                          double daysBack )
{
// mData.showStatus( "Doing HTML search." );

int howMany = 0;

URLFile urlFile = new URLFile( mData );
TimeEC timeEC = new TimeEC();
TimeEC oldTime = new TimeEC();
oldTime.setToNow();
oldTime.addDays( daysBack );
// addHours()
ulong oldIndex = oldTime.getIndex();

int paraCount = 0;
for( int count = 0; count < keySize; count++ )
  {
  if( (count % 20) == 0 )
    {
    if( !mData.checkEvents())
      return;

    }

  if( howMany > 20 )
    break;

  int last = lineArray[count].getArrayLast();
  if( last < 1 )
    continue;

  // mData.showStatus( "Last: " + last );
  for( int countR = 0; countR < last; countR++ )
    {
    lineArray[count].getCopyURLFileAt(
                                    urlFile,
                                    countR );

    ulong linkDateIndex = urlFile.getDateIndex();

    if( linkDateIndex < oldIndex )
      continue;

    // if( urlFile.getYear() < 2024 )
      // continue;

    string url = urlFile.getUrl();
    string urlFrom = url;
    url = Str.toLower( url );

    if( !Str.contains( url, toFindUrl ))
      continue;


    string linkText = urlFile.getLinkText();

    string fileName = urlFile.getFileName();
    string fullPath = mData.
                    getOldDataDirectory() +
                    "URLFiles\\" + fileName;

    if( !SysIO.fileExists( fullPath ))
      continue;

    HtmlFile htmlFile = new HtmlFile( mData,
                                urlFrom,
                                fullPath,
                                linkDateIndex,
                                linkText );

    htmlFile.readFileS();
    htmlFile.markupSections();
    // htmlFile.processNewAnchorTags();

    Story story = new Story( mData, urlFrom,
                  linkDateIndex, linkText );


    int paraCountOne = htmlFile.makeStory( story,
                                     toFind );


    paraCount += paraCountOne;

    story.showStory();

    // if( paraCountOne > 0 )
      // {
      // mData.showStatus( "linkDate: " + linkDate );
      // mData.showStatus( "urlFrom: " + urlFrom );
      // mData.showStatus( " " );
      // }

    howMany++;

    // return;
    }
  }

mData.showStatus( "\r\nParagraph count: " +
                                 paraCount );
}
*/



internal void writeFileS( string toWrite )
{
string fileName = mData.getStoriesFileName();

if( !SysIO.directoryExists(
                  mData.getDataDirectory()))
  {
  mData.showStatus( "No data directory." );
  return;
  }

mData.showStatus( " " );
mData.showStatus( "Writing: " + fileName );

SysIO.writeAllText( fileName, toWrite );
}



internal void writeAllToFile()
{
SBuilder sBuild = new SBuilder();

mData.showStatus( "Writing stories to file." );

// Don't write really old ones:
// TimeEC timeEC = new TimeEC();
// TimeEC oldTime = new TimeEC();
// oldTime.setToNow();
// oldTime.addDays( daysBack );
// ulong oldIndex = oldTime.getIndex();

Story story = new Story( mData );

int howMany = 0;
for( int count = 0; count < keySize; count++ )
  {
  if( (count % 20) == 0 )
    {
    if( !mData.checkEvents())
      return;

    }

  // if( howMany > 20 )
    // break;

  int last = lineArray[count].getArrayLast();
  if( last < 1 )
    continue;

  // mData.showStatus( "Last: " + last );
  for( int countR = 0; countR < last; countR++ )
    {
    lineArray[count].getCopyStoryAt( story,
                                     countR );

    // ulong dateIndex = story.getDateIndex();
    // if( dateIndex < oldIndex )
      // continue;

    sBuild.appendStr( story.toString() +
                      MarkersAI.StoryListDelim );

    howMany++;
    }
  }

string toWrite = sBuild.toString();
writeFileS( toWrite );

mData.showStatus( "Stories: " + howMany );
mData.showStatus( "Finished writing file." );
}




} // Class
