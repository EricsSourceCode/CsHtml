// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public static class GoodLink
{

static internal bool isGoodLink( string link )
{
if( Str.contains( link, "/site/forms/" ))
  return false;

if( Str.contains( link, "/users/admin/" ))
  return false;

if( Str.contains( link, "/users/login/" ))
  return false;

if( Str.contains( link, "/users/signup/" ))
  return false;

if( Str.contains( link, "/classifieds/" ))
  return false;

if( Str.contains( link, "/place_an_ad/" ))
  return false;

if( Str.contains( link, "application/pdf" ))
  return false;

if( Str.contains( link,
                "coloradomtn.edu/download/" ))
  return false;

if( Str.endsWith( link, ".pdf" ))
  return false;

if( Str.endsWith( link, ".php" ))
  return false;

if( Str.contains( link, "&quot" ))
  return false;

if( Str.contains( link, "/../" ))
  return false;

if( Str.endsWith( link, ".aspx" ))
  return false;

if( Str.contains( link, "leadvilleherald.com" ))
  return false;

if( Str.contains( link,
          ".foxnews.com/category/sports/" ))
  return false;

if( Str.contains( link, "coloradomtn.edu/" ))
  return false;

if( Str.contains( link, "https://wa.me/" ))
  return false;

if( Str.contains( link, "mailto:" ))
  return false;

if( Str.contains( link, "ftp://" ))
  return false;

if( Str.contains( link, "sms:" ))
  return false;

if( Str.contains( link, "/privacy-policy" ))
  return false;

if( Str.contains( link, "/obituary" ))
  return false;

if( Str.contains( link, ".foxnews.com/media/" ))
  return false;

if( Str.contains( link,
            ".foxbusiness.com/lifestyle/" ))
  return false;

if( Str.contains( link,
                  ".foxnews.com/opinion/" ))
  return false;

if( Str.contains( link, ".foxnews.com/video/" ))
  return false;

if( Str.contains( link,
                  ".foxnews.com/lifestyle/" ))
  return false;

if( Str.contains( link,
          ".foxbusiness.com/entertainment/" ))
  return false;

if( Str.contains( link,
                   ".foxnews.com/health/" ))
  return false;

// B.S. ads.
if( Str.contains( link,
       ".foxbusiness.com/personal-finance/" ))
  return false;

if( Str.contains( link,
           ".foxnews.com/entertainment/" ))
  return false;

if( Str.contains( link,
                  "www.foxnews.com/shows/" ))
  return false;

if( Str.contains( link,
         "www.foxnews.com/official-polls" ))
  return false;

if( Str.contains( link,
      ".foxbusiness.com/closed-captioning/" ))
  return false;

if( Str.contains( link,
                 ".foxnews.com/about/rss/" ))
  return false;

if( Str.contains( link,
           ".foxnews.com/category/media/" ))
  return false;

if( Str.contains( link,
                 "help.foxbusiness.com" ))
  return false;

if( Str.contains( link,
                "press.foxbusiness.com/" ))
  return false;

if( Str.contains( link,
                  "press.foxnews.com/" ))
  return false;

if( Str.contains( link, ".foxnews.com/rss/" ))
  return false;

if( Str.contains( link,
                  ".foxnews.com/sports/" ))
  return false;

if( Str.contains( link,
               ".foxnews.com/newsletters" ))
  return false;

if( Str.contains( link,
    ".foxnews.com/accessibility-statement" ))
  return false;

if( Str.contains( link,
                 ".foxnews.com/contact" ))
  return false;

if( Str.contains( link,
                   "nation.foxnews.com/" ))
  return false;

if( Str.contains( link,
              ".foxnews.com/compliance" ))
  return false;

if( Str.contains( link,
          ".foxbusiness.com/terms-of-use" ))
  return false;

if( Str.contains( link,
          ".foxnews.com/terms-of-use" ))
  return false;

if( Str.contains( link, "facebook.com/" ))
  return false;

if( Str.contains( link, "twitter.com/" ))
  return false;

if( Str.contains( link, "instagram.com/" ))
  return false;

if( Str.contains( link,
       "ballantinecommunicationsinc.com/" ))
  return false;

if( Str.contains( link, "4cornersjobs.com/" ))
  return false;

if( Str.contains( link, "dgomag.com" ))
  return false;

if( Str.contains( link, "/directoryplus.com" ))
  return false;

if( Str.contains( link,
     "durangoherald-co.newsmemory.com/" ))
  return false;

if( Str.contains( link, "/bcimedia.com" ))
  return false;

if( Str.contains( link,
                  ".fourcornersexpos.com" ))
  return false;

if( Str.contains( link,
           ".foxnews.com/entertainment/" ))
  return false;

if( Str.contains( link,
           "privacy.foxnews.com/" ))
  return false;

if( Str.contains( link,
           "-rss-feeds" ))
  return false;

if( Str.contains( link,
           "/closed-captioning" ))
  return false;


// Good ones.
if( Str.contains( link, ".foxnews.com/" ))
  return true;

if( Str.contains( link, ".msnbc.com/" ))
  return true;

return false;
}



} // Class
