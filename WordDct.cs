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
int highestIndex = 0;

// Two 7 bit ascii values.
private const int keySize = 0x7FFF;



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



internal int getArIndex( string wordIn )
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

if( char2 < 'a' )
  char2 = 'a';

if( char3 < 'a' )
  char3 = 'a';

if( char1 > 'z' )
  char1 = 'z';

if( char2 > 'z' )
  char2 = 'z';

if( char3 > 'z' )
  char3 = 'z';

int index1 = char1 - 'a';
int index2 = char2 - 'a';
int index3 = char3 - 'a';

if( index1 > 26 )
  {
  throw new Exception(
         "This can't happen in WordDct." );
  }

// 5 bits.
int mask = 16 + 8 + 4 + 2 + 1;
if( mask != 0x1F )
  throw new Exception( "Mask is not right." );

int index = index1;
index <<= 5;
index |= index2;
index <<= 5;
index |= index3;

// 15 bits.
if( index > 0x7FFF )
  throw new Exception( "index is too big." );

index = index & keySize;
if( index == keySize )
  throw new Exception( "index > keySize." );

return index;
}





internal void setValue( Word value )
{
try
{
string word = value.getWord();
if( word == null )
  return;

if( word.Length < 1 )
  return;

int arIndex = getArIndex( word );

lineArray[arIndex].setValue( value );
}
catch( Exception )
  {
  throw new Exception(
       "WordDct Exception in setValue()." );
  }
}



internal void getValue( string word,
                        Word toGet )
{
toGet.clear();

if( word == null )
  return;

if( word.Length < 1 )
  return;

int arIndex = getArIndex( word );
if( lineArray[arIndex].getArrayLast() == 0 )
  return;

lineArray[arIndex].getValue( word, toGet );
}



internal bool keyExists( string word )
{
if( word == null )
  return false;

word = Str.trim( word );
if( word.Length < 1 )
  return false;

int arIndex = getArIndex( word );
if( lineArray[arIndex] == null )
  return false;

return lineArray[arIndex].keyExists( word );
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

if( !SysIO.fileExists( fileName ))
  {
  mData.showStatus( "No words file." );
  return;
  }

string fileS = SysIO.readAllText( fileName );

StrAr lines = new StrAr();
lines.split( fileS, MarkersAI.WordListDelim );
int last = lines.getLast();

for( int count = 0; count < last; count++ )
  {
  string line = lines.getStrAt( count );
  // line = Str.trim( line );

  Word word = new Word( mData, "" );
  if( !word.setFromString( line ))
    continue;

  string wordS = word.getWord();
  int index = word.getIndex();
  if( highestIndex < index )
    highestIndex = index;

  // mData.showStatus( "word: " + wordS );
  // mData.showStatus( "index: " + index );
  // if( count > 50 )
    // break;

  lineArray[index].setValue( word );
  }
}




internal void writeFileS( string toWrite )
{
string fileName = mData.getWordsFileName();

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

mData.showStatus( "Writing words to file." );

Word word = new Word( mData, "" );

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
    lineArray[count].getCopyWordAt( word,
                                    countR );

    // It doesn't have a valid index.
    if( word.getIndex() < 1 )
      {
      throw new Exception(
                "Word valid index on write." );
      }

    // ulong dateIndex = story.getDateIndex();
    // if( dateIndex < oldIndex )
      // continue;

    sBuild.appendStr( word.toString() +
                      MarkersAI.WordListDelim );

    howMany++;
    }
  }

string toWrite = sBuild.toString();
writeFileS( toWrite );

mData.showStatus( "Words: " + howMany );
mData.showStatus( "Finished writing file." );
}




internal void addWordsLine( string line )
{
if( line == null )
  return;

line = Str.toLower( line );
line = Str.trim( line );

if( line.Length < 1 )
  return;

StrAr words = new StrAr();
words.split( line, ' ' );
int last = words.getLast();

for( int count = 0; count < last; count++ )
  {
  string word = words.getStrAt( count );
  word = removePunctuation( word );
  word = Str.trim( word );
  if( word.Length < 1 )
    continue;

  if( isBadWord( word ))
    continue;

  if( keyExists( word ))
    continue;

  addWord( word );
  }
}




internal string removePunctuation( string word )
{
string result = "";

if( Str.endsWith( word, "\'" ))
  word = Str.replace( word, "\'", "" );

if( Str.startsWith( word, "\'" ))
  word = Str.replace( word, "\'", "" );

int last = word.Length;
for( int count = 0; count < last; count++ )
  {
  char letter = word[count];
  if( letter == '.' )
    continue;

  if( letter == ',' )
    continue;

  if( letter == ';' )
    continue;

  if( letter == ':' )
    continue;

  if( letter == '!' )
    continue;

  if( letter == '?' )
    continue;

  if( letter == '(' )
    continue;

  if( letter == ')' )
    continue;

  if( letter == '$' )
    continue;

  // For AI it would matter that these stay
  // like they are.
  // '  you've
  // digital's word ends with: 's
  // walz's  china's
  // And AI needs the context of the whole
  // word, like provided, and not just provide.
  // delayed means something different from
  // delay.


  // Ampersand is like this: &#8217;
  // Not just this: #2024
  if( letter == '#' )
    continue;

  // These are really one word.
  // opt-out
  // real-time

  if( letter == '\"' )
    continue;

  // 0 to 9
  if( (letter >= '0') && (letter <= '9') )
    continue;

  result += word[count];
  }

return result;
}



internal bool isBadWord( string word )
{
// An email address:
if( Str.contains( word, "@" ))
  return true;

return false;
}




private void addWord( string wordS )
{
if( keyExists( wordS ))
  return;

mData.showStatus( "New word: " + wordS );

Word toAdd = new Word( mData, wordS );

// It is at the highest index it found,
// so add one to make a new higher index
// than what is in the data.
highestIndex++;
toAdd.setIndex( highestIndex );
// toAdd.count = 0;
setValue( toAdd );
}



} // Class
