// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class Paragraph
{
private MainData mData;
private string fromURL = "";
private string paraStr = "";



private Paragraph()
{
}


internal Paragraph( MainData mDataToUse,
                   string useBaseURL )
{
mData = mDataToUse;
fromURL = useBaseURL;
// baseDomain = getDomainFromLink( fromURL );
// baseHttpS = "https://" + baseDomain;
}



internal string getParaStr()
{
return paraStr;
}




internal void clear()
{
paraStr = "";
// Leave fromURL alone.
}


} // Class
