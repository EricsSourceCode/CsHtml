// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class NonAscii
{
// private MainData mData;



internal static string fixIt( string inS )
{
string result = inS;

if( result.Length < 1 )
  return "";

// Just blank.
if( Str.contains( result, "" + (char)160 ))
  {
  result = Str.replace( result,
              "" + (char)160, " " );
  }

/*
  if( c == 163 ) // strange character
    continue;
    // c = '#';

  if( c == 167 ) // strange character
    continue;
*/

if( Str.contains( result, "" + (char)169 ))
  {
  result = Str.replace( result,
              "" + (char)169, "(c)" );
  }


/*
  if( c == 173 )
    c = '-';

  if( c == 174 ) // Rights symbol
    continue;

  if( c == 176 ) // Little circle
    continue;

  if( c == 177 ) // +- symbol
    continue;


*/

if( Str.contains( result, "" + (char)180 ))
  {
  result = Str.replace( result,
              "" + (char)180, "\'" );
  }

if( Str.contains( result, "" + (char)188 ))
  {
  result = Str.replace( result,
              "" + (char)188, "1/4" );
  }

if( Str.contains( result, "" + (char)189 ))
  {
  result = Str.replace( result,
              "" + (char)189, "1/2" );
  }

if( Str.contains( result, "" + (char)190 ))
  {
  result = Str.replace( result,
              "" + (char)190, "3/4" );
  }

if( Str.contains( result, "" + (char)194 ))
  {
  result = Str.replace( result,
              "" + (char)194, "A" );
  }

if( Str.contains( result, "" + (char)201 ))
  {
  result = Str.replace( result,
              "" + (char)201, "E" );
  }

if( Str.contains( result, "" + (char)214 ))
  {
  result = Str.replace( result,
              "" + (char)214, "O" );
  }

if( Str.contains( result, "" + (char)216 ))
  {
  result = Str.replace( result,
              "" + (char)216, "O" );
  }

if( Str.contains( result, "" + (char)224 ))
  {
  result = Str.replace( result,
              "" + (char)224, "a" );
  }

if( Str.contains( result, "" + (char)225 ))
  {
  result = Str.replace( result,
              "" + (char)225, "a" );
  }

if( Str.contains( result, "" + (char)226 ))
  {
  result = Str.replace( result,
              "" + (char)226, "a" );
  }

if( Str.contains( result, "" + (char)227 ))
  {
  result = Str.replace( result,
              "" + (char)227, "a" );
  }

if( Str.contains( result, "" + (char)229 ))
  {
  result = Str.replace( result,
              "" + (char)229, "a" );
  }

if( Str.contains( result, "" + (char)231 ))
  {
  result = Str.replace( result,
              "" + (char)231, "c" );
  }

if( Str.contains( result, "" + (char)232 ))
  {
  result = Str.replace( result,
              "" + (char)232, "e" );
  }

if( Str.contains( result, "" + (char)233 ))
  {
  result = Str.replace( result,
              "" + (char)233, "e" );
  }

if( Str.contains( result, "" + (char)234 ))
  {
  result = Str.replace( result,
              "" + (char)234, "e" );
  }

if( Str.contains( result, "" + (char)235 ))
  {
  result = Str.replace( result,
              "" + (char)235, "e" );
  }

if( Str.contains( result, "" + (char)236 ))
  {
  result = Str.replace( result,
              "" + (char)236, "i" );
  }

if( Str.contains( result, "" + (char)237 ))
  {
  result = Str.replace( result,
              "" + (char)237, "i" );
  }

if( Str.contains( result, "" + (char)238 ))
  {
  result = Str.replace( result,
              "" + (char)238, "i" );
  }

if( Str.contains( result, "" + (char)239 ))
  {
  result = Str.replace( result,
              "" + (char)239, "i" );
  }

if( Str.contains( result, "" + (char)240 ))
  {
  result = Str.replace( result,
              "" + (char)240, "o" );
  }

if( Str.contains( result, "" + (char)241 ))
  {
  result = Str.replace( result,
              "" + (char)241, "n" );
  }


if( Str.contains( result, "" + (char)243 ))
  {
  result = Str.replace( result,
              "" + (char)243, "o" );
  }

if( Str.contains( result, "" + (char)244 ))
  {
  result = Str.replace( result,
              "" + (char)244, "o" );
  }

if( Str.contains( result, "" + (char)246 ))
  {
  result = Str.replace( result,
              "" + (char)246, "o" );
  }


/*
  if( c == 248 ) // Sort of a Phi.
    continue;
*/

if( Str.contains( result, "" + (char)249 ))
  {
  result = Str.replace( result,
              "" + (char)249, "u" );
  }

if( Str.contains( result, "" + (char)250 ))
  {
  result = Str.replace( result,
              "" + (char)250, "u" );
  }

if( Str.contains( result, "" + (char)251 ))
  {
  result = Str.replace( result,
              "" + (char)251, "u" );
  }

if( Str.contains( result, "" + (char)252 ))
  {
  result = Str.replace( result,
              "" + (char)252, "u" );
  }

if( Str.contains( result, "" + (char)257 ))
  {
  result = Str.replace( result,
              "" + (char)257, "a" );
  }


if( Str.contains( result, "" + (char)263 ))
  {
  result = Str.replace( result,
              "" + (char)263, "c" );
  }

if( Str.contains( result, "" + (char)268 ))
  {
  result = Str.replace( result,
              "" + (char)268, "C" );
  }

if( Str.contains( result, "" + (char)281 ))
  {
  result = Str.replace( result,
              "" + (char)281, "e" );
  }

if( Str.contains( result, "" + (char)283 ))
  {
  result = Str.replace( result,
              "" + (char)283, "e" );
  }

if( Str.contains( result, "" + (char)287 ))
  {
  result = Str.replace( result,
              "" + (char)287, "g" );
  }

if( Str.contains( result, "" + (char)333 ))
  {
  result = Str.replace( result,
              "" + (char)333, "o" );
  }

if( Str.contains( result, "" + (char)347 ))
  {
  result = Str.replace( result,
              "" + (char)347, "s" );
  }

if( Str.contains( result, "" + (char)380 ))
  {
  result = Str.replace( result,
              "" + (char)380, "z" );
  }

if( Str.contains( result, "" + (char)699 ))
  {
  result = Str.replace( result,
              "" + (char)699, "\'" );
  }

if( Str.contains( result, "" + (char)700 ))
  {
  result = Str.replace( result,
              "" + (char)700, "\'" );
  }

if( Str.contains( result, "" + (char)1057 ))
  {
  result = Str.replace( result,
              "" + (char)1057, "C" );
  }

if( Str.contains( result, "" + (char)8201 ))
  {
  result = Str.replace( result,
              "" + (char)8201, " " );
  }

if( Str.contains( result, "" + (char)8202 ))
  {
  result = Str.replace( result,
              "" + (char)8202, " " );
  }


// Not showing.
if( Str.contains( result, "" + (char)8203 ))
  {
  result = Str.replace( result,
              "" + (char)8203, " " );
  }


/*
  if( c == 8208 ) // dash or hyphen?
    c = '-';

*/


if( Str.contains( result, "" + (char)8211 ))
  {
  result = Str.replace( result,
              "" + (char)8211, "-" );
  }

if( Str.contains( result, "" + (char)8212 ))
  {
  result = Str.replace( result,
              "" + (char)8212, "-" );
  }


/*
  if( c == 8213 ) // dash or hyphen?
    c = '-';

*/


if( Str.contains( result, "" + (char)8216 ))
  {
  result = Str.replace( result,
              "" + (char)8216, "\'" );
  }

if( Str.contains( result, "" + (char)8217 ))
  {
  result = Str.replace( result,
              "" + (char)8217, "\'" );
  }

if( Str.contains( result, "" + (char)8220 ))
  {
  result = Str.replace( result,
              "" + (char)8220, "\"" );
  }

if( Str.contains( result, "" + (char)8221 ))
  {
  result = Str.replace( result,
              "" + (char)8221, "\"" );
  }


// a Dot.
if( Str.contains( result, "" + (char)8226 ))
  {
  result = Str.replace( result,
              "" + (char)8226, "(*)" );
  }

if( Str.contains( result, "" + (char)8230 ))
  {
  result = Str.replace( result,
              "" + (char)8230, "..." );
  }

// Not showing.
if( Str.contains( result, "" + (char)8239 ))
  {
  result = Str.replace( result,
              "" + (char)8239, " " );
  }

if( Str.contains( result, "" + (char)8294 ))
  {
  result = Str.replace( result,
              "" + (char)8294, "[LRI]" );
  }

if( Str.contains( result, "" + (char)8297 ))
  {
  result = Str.replace( result,
              "" + (char)8297, "[PDI]" );
  }


// Trademark.
/*
if( Str.contains( result, "" + (char)8492 ))
  {
  result = Str.replace( result,
              "" + (char)8492, "(Tr)" );
  }
*/

if( Str.contains( result, "" + (char)8531 ))
  {
  result = Str.replace( result,
              "" + (char)8531, "1/3" );
  }

if( Str.contains( result, "" + (char)8539 ))
  {
  result = Str.replace( result,
              "" + (char)8539, "1/8" );
  }


return result;
}



} // Class
