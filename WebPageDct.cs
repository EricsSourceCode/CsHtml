// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



using System;



// namespace



public class WebPageDct
{
private MainData mData;
private WebPageDctLine[] lineArray;
private const int keySize = 0xFFF;
private ByteBuf resultHash;
private ByteBuf message;


private WebPageDct()
{
}



internal WebPageDct( MainData useMainData )
{
mData = useMainData;

try
{
lineArray = new WebPageDctLine[keySize];
for( int count = 0; count < keySize; count++ )
  lineArray[count] = new WebPageDctLine( mData );

resultHash = new ByteBuf();
message = new ByteBuf();

}
catch( Exception Except )
  {
  freeAll();
  mData.showStatus(
     "Not enough memory for WebPageDctLines." );
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
url = Str.trim( url );
url = Str.toLower( url );

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
                        WebPage value )
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
       "WebPageDct Exception in setValue()." );
  }
}



internal void getValue( string key,
                        WebPage toGet )
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

string fileName = mData.getStoriesFileName();

mData.showStatus( "Reading file:" );
mData.showStatus( fileName );

if( !SysIO.directoryExists(
                  mData.getDataDirectory()))
  {
  mData.showStatus( "No data directory." );
  return;
  }

if( !SysIO.fileExists( fileName ))
  {
  mData.showStatus( "No stories file." );
  return;
  }

string fileS = SysIO.readAllText( fileName );

StrAr lines = new StrAr();
lines.split( fileS, MarkersAI.WebPageListDelim );
int last = lines.getLast();

for( int count = 0; count < last; count++ )
  {
  string line = lines.getStrAt( count );
  // line = Str.trim( line );

  WebPage webPage = new WebPage( mData );
  if( !webPage.setFromString( line ))
    continue;

  string url = webPage.getUrl();
  int index = getIndex( url );

  // mData.showStatus( "url: " + url );
  // mData.showStatus( "index: " + index );
  // if( count > 50 )
    // break;

  lineArray[index].setValue( webPage );
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

    // story.showStory();

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

WebPage webPage = new WebPage( mData );

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
    lineArray[count].getCopyWebPageAt( webPage,
                                     countR );

    // ulong dateIndex = story.getDateIndex();
    // if( dateIndex < oldIndex )
      // continue;

    sBuild.appendStr( webPage.toString() +
                   MarkersAI.WebPageListDelim );

    howMany++;
    }
  }

string toWrite = sBuild.toString();
writeFileS( toWrite );

mData.showStatus( "Web Pages: " + howMany );
mData.showStatus( "Finished writing file." );
}




internal void webPageSearch( string toFindUrl,
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

// False is Republican.
// bool isDemocrat = Str.contains( toFindUrl,
//                                "msnbc" );

int howMany = 0;

WebPage webPage = new WebPage( mData );
for( int count = 0; count < keySize; count++ )
  {
  if( (count % 20) == 0 )
    {
    if( !mData.checkEvents())
      return;

    }

  howMany++;
  if( howMany > 50000000 )
    break;

  int last = lineArray[count].getArrayLast();
  if( last < 1 )
    continue;

  // mData.showStatus( "Last: " + last );
  for( int countR = 0; countR < last; countR++ )
    {
    lineArray[count].getCopyWebPageAt( webPage,
                                       countR );

    ulong linkDateIndex = webPage.getDateIndex();

    if( linkDateIndex < oldIndex )
      continue;

    string url = webPage.getUrl();
    url = Str.toLower( url );
    if( !Str.contains( url, toFindUrl ))
      continue;

    string linkText = webPage.getLinkText();
    string linkTextLower =
                      Str.toLower( linkText );

    if( !Str.contains( linkTextLower, toFind ))
      continue;

    // string wordsLine = story.getWordsLine();
    // wordDct.addWordsLine( wordsLine );
    // if( isDemocrat )

    // mData.showStatus( linkText );

    webPage.showWebPage();
    }
  }
}




internal void neuralSearch( // string toFindUrl,
                     // string toFind,
                     double daysBack,
                     VectorArray paragMatrix,
                     VectorArray labelMatrix )
{
// toFindUrl = Str.toLower( toFindUrl );
// toFind = Str.toLower( toFind );

TimeEC timeEC = new TimeEC();
TimeEC oldTime = new TimeEC();
oldTime.setToNow();
oldTime.addDays( daysBack );
// addHours()
ulong oldIndex = oldTime.getIndex();

// mData.showStatus( "oldIndex: " + oldIndex );

int howMany = 0;


paragMatrix.clearLastAppend();
labelMatrix.clearLastAppend();

int labelCol = labelMatrix.getColumns();
VectorFlt labelSet = new VectorFlt( mData );
labelSet.setSize( labelCol );

float isDemocrat = 1;
float isRepub = 1;
WebPage webPage = new WebPage( mData );
for( int count = 0; count < keySize; count++ )
  {
  if( (count % 20) == 0 )
    {
    if( !mData.checkEvents())
      return;

    }

  howMany++;
  if( howMany > 50000000 )
    break;

  int last = lineArray[count].getArrayLast();
  if( last < 1 )
    continue;

  // mData.showStatus( "Last: " + last );
  for( int countR = 0; countR < last; countR++ )
    {
    lineArray[count].getCopyWebPageAt( webPage,
                                     countR );

    ulong linkDateIndex = webPage.getDateIndex();

    if( linkDateIndex < oldIndex )
      continue;

    string url = webPage.getUrl();
    url = Str.toLower( url );

    // if( !Str.contains( url, toFindUrl ))
      // continue;

    if( Str.contains( url, "msnbc" ))
      {
      isDemocrat = 1;
      isRepub = 0;
      }
    else
      {
      isDemocrat = 0;
      isRepub = 1;
      }

    // string linkText = story.getLinkText();
    // string linkTextLower =
    //                  Str.toLower( linkText );

    // if( !Str.contains( linkTextLower, toFind ))
      // continue;

    int lastAppend = paragMatrix.getLastAppend();
    if( lastAppend != labelMatrix.getLastAppend())
      {
      throw new Exception(
        "WebPageDct labelMatrix last append." );
      }

    labelSet.clearZeros();
    labelSet.setVal( 1, isDemocrat );
    labelSet.setVal( 2, isRepub );

    labelMatrix.appendVecCopy( labelSet );

    string parags = webPage.getParagsVecText();
    paragMatrix.appendFromString( parags );
    }
  }
}




} // Class
