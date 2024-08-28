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

if( Str.contains( para,
    "this material may not be published, " +
    "broadcast, rewritten," ))
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

if( para == "subscribed" )
  return false;

if( para == "<i" )
  return false;

if( para == "(c) 2024 nbc universal" )
  return false;


if( Str.contains( para,
    "you've successfully subscribed to this" ))
  return false;

if( Str.contains( para,
    "by entering your email and clicking" ))
return false;

if( Str.contains( para,
    "you agree to the fox news privacy" ))
  return false;

if( Str.contains( para,
   "kurt \"cyberguy\" knutsson is an award-" ))
  return false;

return true;
}



} // Class
