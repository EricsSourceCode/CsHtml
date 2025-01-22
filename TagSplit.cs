// Copyright Eric Chauvin 2024 - 2025.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class TagSplit
{
private MainData mData;
private string tagText = "";



private TagSplit()
{
}


public TagSplit( MainData useMData )
{
mData = useMData;
}


internal void setTagText( string inS )
{
// Tag: <input type="search" class=
// "search-input js-search-input" 

tagText = inS;

}



internal string getTagText()
{
return tagText;
}



internal bool isTagToShow()
{
if( Str.contains( tagText, 
        "data-testid=\"playlist-duration\"" ))
  return false;


return true;
}



} // Class
