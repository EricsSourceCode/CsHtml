// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class Story
{
private MainData mData;
// There is no title.
// private string linkText = "";
private string urlFrom = "";
private StrAr paraAr;
// DateTime when it was downloaded.



private Story()
{
}


internal Story( MainData mDataToUse,
                string useURL )
{
mData = mDataToUse;
urlFrom = useURL;
paraAr = new StrAr();
}



internal void appendParaG( string para )
{
paraAr.append( para );
}





} // Class
