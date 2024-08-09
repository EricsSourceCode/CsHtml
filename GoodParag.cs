// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public static class GoodParag
{

static internal bool isGoodParag( string para )
{
para = Str.toLower( para );
para = Str.trim( para );

if( Str.contains( para,
                  "class=\"copyright\"" ) ||
    Str.contains( para,
               "class=\"subscribed hide\"" ) ||
    Str.contains( para,
               "class=\"success hide\"" ) ||
    Str.contains( para,
               "class=\"dek\"" ) ||
    Str.contains( para,
      ".foxnews.com/download" ))
  return false;

if( para == "featured shows" )
  return false;

if( para == "weekday shows" )
  return false;

if( para == "weekend shows" )
  return false;

if( para == "msnbc tv" )
  return false;

if( para == "more" )
  return false;

if( para == "follow msnbc" )
  return false;

if( para == "more brands" )
  return false;

if( para == "more shows" )
  return false;


return true;
}



} // Class
