// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



using System;



// namespace



public class WordDct
{
private MainData mData;
private WordDctLine[] lineArray;

// Two 7 bit ascii values.
private const int keySize = 0x3FFF;

// private ByteBuf resultHash;
// private ByteBuf message;


private WordDct()
{
}



internal WordDct( MainData useMainData )
{
mData = useMainData;

try
{
lineArray = new WordDctLine[keySize];
for( int count = 0; count < keySize; count++ )
  lineArray[count] = new WordDctLine( mData );

// resultHash = new ByteBuf();
// message = new ByteBuf();

}
catch( Exception Except )
  {
  freeAll();
  mData.showStatus(
     "Not enough memory for WordDct." );
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



internal int getIndex( string wordIn )
{
wordIn = Str.trim( wordIn );
wordIn = Str.toLower( wordIn );

int len = wordIn.Length;
if( len == 0 )
  return 0;

char char1 = wordIn[0];
char char2 = 'a';
char char3 = 'a';

// Little 'a' is 97.

if( len >= 2 )
  char2 = wordIn[1];

if( len >= 3 )
  char3 = wordIn[2];

// Little 'a' is 97.
if( char1 < 'a' )
  char1 = 'a';

int index = 0;


index = index & keySize;
if( index == keySize )
  index = keySize - 1;

return index;
}




/*
internal void setValue( string key,
                        Story value )
{
try
{
if( key == null )
  return;

key = Str.trim( key );

if( key.Length < 1 )
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



internal bool keyExists( string url )
{
if( url == null )
  return false;

url = Str.trim( url );
url = Str.toLower( url );
if( url.Length < 1 )
  return false;

int index = getIndex( url );
if( lineArray[index] == null )
  return false;

return lineArray[index].keyExists( url );
}




internal void readAllFromFile()
{
clear();

string fileName = mData.getWordsFileName();

mData.showStatus( "Reading words file:" );
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
*/




/*
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




internal void storySearch( string toFindUrl,
                          string toFind,
                          double daysBack )
{
toFindUrl = Str.toLower( toFindUrl );
toFind = Str.toLower( toFind );

TimeEC timeEC = new TimeEC();
TimeEC oldTime = new TimeEC();
oldTime.setToNow();
oldTime.addDays( daysBack );
// addHours()
ulong oldIndex = oldTime.getIndex();

// mData.showStatus( "oldIndex: " + oldIndex );

Story story = new Story( mData );
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

    ulong linkDateIndex = story.getDateIndex();

    if( linkDateIndex < oldIndex )
      continue;

    string url = story.getUrl();
    url = Str.toLower( url );
    if( !Str.contains( url, toFindUrl ))
      continue;

    string linkText = story.getLinkText();
    string linkTextLower =
                      Str.toLower( linkText );

    if( !Str.contains( linkTextLower, toFind ))
      continue;

    // mData.showStatus( linkText );
    story.showStory();




/////////////
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

    if( htmlFile.makeStory( story ))
      {
      storyDct.setValue( story.getUrl(), story );
      story.showStory();
      }
////////////////


    // howMany++;
    }
  }
}
*/




} // Class
