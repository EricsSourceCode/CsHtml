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

// Upside down exclamation.
if( Str.contains( result, "" + (char)161 ))
  {
  result = Str.replace( result,
              "" + (char)161, "(!)" );
  }

if( Str.contains( result, "" + (char)163 ))
  {
  result = Str.replace( result,
              "" + (char)163, "(pound$)" );
  }

if( Str.contains( result, "" + (char)167 ))
  {
  result = Str.replace( result,
              "" + (char)167, "(*section)" );
  }

if( Str.contains( result, "" + (char)169 ))
  {
  result = Str.replace( result,
              "" + (char)169, "(c)" );
  }

if( Str.contains( result, "" + (char)173 ))
  {
  result = Str.replace( result,
              "" + (char)173, "-" );
  }

// Rights symbol
if( Str.contains( result, "" + (char)174 ))
  {
  result = Str.replace( result,
              "" + (char)174, "(R)" );
  }

// A little circle.
if( Str.contains( result, "" + (char)176 ))
  {
  result = Str.replace( result,
              "" + (char)176, "(*)" );
  }

if( Str.contains( result, "" + (char)177 ))
  {
  result = Str.replace( result,
              "" + (char)177, "+/-" );
  }

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

// Upside down question mark.
if( Str.contains( result, "" + (char)191 ))
  {
  result = Str.replace( result,
              "" + (char)191, "(?)" );
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

if( Str.contains( result, "" + (char)205 ))
  {
  result = Str.replace( result,
              "" + (char)205, "I" );
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

if( Str.contains( result, "" + (char)248 ))
  {
  result = Str.replace( result,
              "" + (char)248, "(Phi)" );
  }

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

if( Str.contains( result, "" + (char)259 ))
  {
  result = Str.replace( result,
              "" + (char)259, "a" );
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

if( Str.contains( result, "" + (char)299 ))
  {
  result = Str.replace( result,
              "" + (char)299, "i" );
  }

if( Str.contains( result, "" + (char)304 ))
  {
  result = Str.replace( result,
              "" + (char)304, "I" );
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

if( Str.contains( result, "" + (char)363 ))
  {
  result = Str.replace( result,
              "" + (char)363, "u" );
  }

if( Str.contains( result, "" + (char)380 ))
  {
  result = Str.replace( result,
              "" + (char)380, "z" );
  }

if( Str.contains( result, "" + (char)382 ))
  {
  result = Str.replace( result,
              "" + (char)382, "z" );
  }

if( Str.contains( result, "" + (char)537 ))
  {
  result = Str.replace( result,
              "" + (char)537, "s" );
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

// Canadian Aboriginal Syllabics 
// Weird upside down comma that causes problems.
if( Str.contains( result, "" + (char)1548 ))
  {
  result = Str.replace( result,
              "" + (char)1548, "(,)" );
  }

if( Str.contains( result, "" + (char)7717 ))
  {
  result = Str.replace( result,
              "" + (char)7717, "h" );
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

// Not showing.
if( Str.contains( result, "" + (char)8206 ))
  {
  result = Str.replace( result,
              "" + (char)8206, " " );
  }

if( Str.contains( result, "" + (char)8208 ))
  {
  result = Str.replace( result,
              "" + (char)8208, "-" );
  }

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

if( Str.contains( result, "" + (char)8213 ))
  {
  result = Str.replace( result,
              "" + (char)8213, "-" );
  }


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

if( Str.contains( result, "" + (char)8243 ))
  {
  result = Str.replace( result,
              "" + (char)8243, "\"" );
  }

// Not showing
if( Str.contains( result, "" + (char)8288 ))
  {
  result = Str.replace( result,
              "" + (char)8288, " " );
  }

if( Str.contains( result, "" + (char)8294 ))
  {
  result = Str.replace( result,
              "" + (char)8294, "[LRI]" );
  }

// CJK Unified Ideograp
if( Str.contains( result, "" + (char)8297 ))
  {
  result = Str.replace( result,
              "" + (char)8297, "[PDI]" );
  }

if( Str.contains( result, "" + (char)8364 ))
  {
  result = Str.replace( result,
              "" + (char)8364, "(euro$)" );
  }

if( Str.contains( result, "" + (char)8457 ))
  {
  result = Str.replace( result,
              "" + (char)8457, "(Farenheit)" );
  }


// Trademark.
if( Str.contains( result, "" + (char)8482 ))
  {
  result = Str.replace( result,
              "" + (char)8482, "(Tm)" );
  }

if( Str.contains( result, "" + (char)8531 ))
  {
  result = Str.replace( result,
              "" + (char)8531, "1/3" );
  }

if( Str.contains( result, "" + (char)8532 ))
  {
  result = Str.replace( result,
              "" + (char)8532, "2/3" );
  }

if( Str.contains( result, "" + (char)8539 ))
  {
  result = Str.replace( result,
              "" + (char)8539, "1/8" );
  }

if( Str.contains( result, "" + (char)9654 ))
  {
  result = Str.replace( result,
              "" + (char)9654, "(triangle*)" );
  }


return result;
}



} // Class
