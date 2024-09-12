// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public static class Ampersand
{

public static string fixChars( string inS )
{
string result = inS;

result = Str.replace( result, "&copy;", "(c)" );
result = Str.replace( result, "&nbsp;", " " );
result = Str.replace( result, "&#x27;", "'" );
result = Str.replace( result, "&#39;", "'" );
result = Str.replace( result, "&#x2013;", "-" );
result = Str.replace( result, "&#x2019;", "'" );
result = Str.replace( result, "&#x2018;", "'" );
result = Str.replace( result, "&#8217;", "'" );
result = Str.replace( result, "&amp;", "&" );
result = Str.replace( result, "&quot;", "\"" );
result = Str.replace( result, "&aacute;",
                      "" + (char)0x00E1 );

/*
    result = result.replace(
                            new StrA( "&nacute;" ),
                            new StrA(
            Character.toString( (char)0x0144 )));

    result = result.replace(
                            new StrA( "&iacute;" ),
                            new StrA(
            Character.toString( (char)0x00ED )));

    result = result.replace(
                            new StrA( "&ntilde;" ),
                            new StrA(
            Character.toString( (char)0x00F1 )));



// ampersand &amp; &#38; &#x26; & & &
// less-than sign &lt; &#60; &#x3C; < < <
// greater-than sign &gt; &#62; &#x3E; > > >
// Latin capital ligature OE &OElig; &#338; &#x152;
// Latin small ligature oe &oelig; &#339; &#x153;
// Latin capital letter S with caron
                      &Scaron; &#352; &#x160;
// Latin small letter s with caron
                      &scaron; &#353; &#x161;
// Latin capital letter Y with diaeresis
                        &Yuml; &#376; &#x178;
// modifier letter circumflex accent &circ;
                               &#710; &#x2C6;
// small tilde &tilde; &#732; &#x2DC;
// en space &ensp; &#8194; &#x2002;
// em space &emsp; &#8195; &#x2003;
// thin space &thinsp; &#8201; &#x2009;
// zero width non-joiner &zwnj; &#8204; &#x200C;
// zero width joiner &zwj; &#8205; &#x200D;
// left-to-right mark &lrm; &#8206; &#x200E;
// right-to-left mark &rlm; &#8207; &#x200F;
// en dash &ndash; &#8211; &#x2013;
// em dash &mdash; &#8212; &#x2014;
// left single quotation mark &lsquo;
                               &#8216; &#x2018;
// right single quotation mark &rsquo;
                                &#8217; &#x2019;
// single low-9 quotation mark &sbquo;
                              &#8218; &#x201A;
// left double quotation mark &ldquo;
                           &#8220; &#x201C;
// right double quotation mark &rdquo;
                          &#8221; &#x201D;
// double low-9 quotation mark &bdquo;
                         &#8222; &#x201E;
// dagger &dagger; &#8224; &#x2020;
// double dagger &Dagger; &#8225; &#x2021;
// per mille sign &permil; &#8240; &#x2030;
// single left-pointing angle quotation
                 mark &lsaquo; &#8249; &#x2039;
// single right-pointing angle
         quotation mark &rsaquo; &#8250; &#x203A;
// euro sign &euro; &#8364; &#x20AC;





&aring; 00E5
&aelig; 00E6
&ccedil; 00E7
&egrave; 00E8
&eacute; 00E9
&ecirc; 00EA
&euml; 00EB
&igrave; 00EC
&icirc; 00EE
&iuml; 00EF
&eth; 00F0
&ograve; 00F2
&oacute; 00F3
&ocirc; 00F4
&otilde; 00F5
&ouml; 00F6
&divide; 00F7
&oslash; 00F8
&ugrave; 00F9
&uacute; 00FA
&ucirc; 00FB
&uuml; 00FC
&yacute; 00FD
&thorn; 00FE
&yuml; 00FF
&Amacr; 0100
&amacr; 0101
&Abreve; 0102
&abreve; 0103
&Aogon; 0104
&aogon; 0105
&Cacute; 0106
&cacute; 0107
&Ccirc; 0108
&ccirc; 0109
&Cdot; 010A
&cdot; 010B
&Ccaron; 010C
&ccaron; 010D
&Dcaron; 010E
&dcaron; 010F
&Dstrok; 0110
&dstrok; 0111
&Emacr; 0112
&emacr; 0113
&Edot; 0116
&edot; 0117
&Eogon; 0118
&eogon; 0119
&Ecaron; 011A
&ecaron; 011B
&Gcirc; 011C
&gcirc; 011D
&Gbreve; 011E
&gbreve; 011F
&Gdot; 0120
&gdot; 0121
&Gcedil; 0122
&Hcirc; 0124
&hcirc; 0125
&Hstrok; 0126
&hstrok; 0127
&Itilde; 0128
&itilde; 0129
&Imacr; 012A
&imacr; 012B
&Iogon; 012E
&iogon; 012F
&Idot; 0130
&imath; 0131
&IJlig; 0132
&ijlig; 0133
&Jcirc; 0134
&jcirc; 0135
&Kcedil; 0136
&kcedil; 0137
&kgreen; 0138
&Lacute; 0139
&lacute; 013A
&Lcedil; 013B
&lcedil; 013C
&Lcaron; 013D
&lcaron; 013E
&Lmidot; 013F
&lmidot; 0140
&Lstrok; 0141
&lstrok; 0142
&Nacute; 0143
&Ncedil; 0145
&ncedil; 0146
&Ncaron; 0147
&ncaron; 0148
&napos; 0149
&ENG; 014A
&eng; 014B
&Omacr; 014C
&omacr; 014D
/////////



/////////

&aacute; U+00E1
&Aacute; U+00C1
&acirc; U+00E2
&Acirc; U+00C2
&acute; U+00B4
&aelig; U+00E6
&AElig; U+00C6
&agrave; U+00E0
&Agrave; U+00C0
&alefsym; U+2135
&alpha; U+03B1
&Alpha; U+0391
&amp; U+0026
&and; U+2227
&ang; U+2220
&aring; U+00E5
&Aring; U+00C5
&asymp; U+2248
&atilde; U+00E3
&Atilde; U+00C3
&auml; U+00E4
&Auml; U+00C4
&bdquo; U+201E
&beta; U+03B2
&Beta; U+0392
&brvbar; U+00A6
&bull; U+2022
&cap; U+2229
&ccedil; U+00E7
&Ccedil; U+00C7
&cedil; U+00B8
&cent; U+00A2
&chi; U+03C7
&Chi; U+03A7
&circ; U+02C6
&clubs; U+2663
&cong; U+2245
&copy; U+00A9
&crarr; U+21B5
&cup; U+222A
&curren; U+00A4
&dagger; U+2020
&Dagger; U+2021
&darr; U+2193
&dArr; U+21D3
&deg; U+00B0
&delta; U+03B4
&Delta; U+0394
&diams; U+2666
&divide; U+00F7
&eacute; U+00E9
&Eacute; U+00C9
&ecirc; U+00EA
&Ecirc; U+00CA
&egrave; U+00E8
&Egrave; U+00C8
&empty; U+2205
&emsp; U+2003
&ensp; U+2002
&epsilon; U+03B5
&Epsilon; U+0395
&equiv; U+2261
&eta; U+03B7
&Eta; U+0397
&eth; U+00F0
&ETH; U+00D0
&euml; U+00EB
&Euml; U+00CB
&euro; U+20AC
&exist; U+2203
&fnof; U+0192
&forall; U+2200
&frac12; U+00BD
&frac14; U+00BC
&frac34; U+00BE
&frasl; U+2044
&gamma; U+03B3
&Gamma; U+0393
&ge; U+2265
&gt; U+003E
&harr; U+2194
&hArr; U+21D4
&hearts; U+2665
&hellip; U+2026
&iacute; U+00ED
&Iacute; U+00CD
&icirc; U+00EE
&Icirc; U+00CE
&iexcl; U+00A1
&igrave; U+00EC
&Igrave; U+00CC
&image; U+2111
&infin; U+221E
&int; U+222B
&iota; U+03B9
&Iota; U+0399
&iquest; U+00BF
&isin; U+2208
&iuml; U+00EF
&Iuml; U+00CF
&kappa; U+03BA
&Kappa; U+039A
&lambda; U+03BB
&Lambda; U+039B
&lang; U+2329
&laquo; U+00AB
&larr; U+2190
&lArr; U+21D0
&lceil; U+2308
&ldquo; U+201C
&le; U+2264
&lfloor; U+230A
&lowast; U+2217
&loz; U+25CA
&lrm; U+200E
&lsaquo; U+2039
&lsquo; U+2018
&lt; U+003C
&macr; U+00AF
&mdash; U+2014
&micro; U+00B5
&middot; U+00B7
&minus; U+2212
&mu; U+03BC
&Mu; U+039C
&nabla; U+2207
&nbsp; U+00A0
&ndash; U+2013
&ne; U+2260
&ni; U+220B
&not; U+00AC
&notin; U+2209
&nsub; U+2284
&ntilde; U+00F1
&Ntilde; U+00D1
&nu; U+03BD
&Nu; U+039D
&oacute; U+00F3
&Oacute; U+00D3
&ocirc; U+00F4
&Ocirc; U+00D4
&oelig; U+0153
&OElig; U+0152
&ograve; U+00F2
&Ograve; U+00D2
&oline; U+203E
&omega; U+03C9
&Omega; U+03A9
&omicron; U+03BF
&Omicron; U+039F
&oplus; U+2295
&or; U+2228
&ordf; U+00AA
&ordm; U+00BA
&oslash; U+00F8
&Oslash; U+00D8
&otilde; U+00F5
&Otilde; U+00D5
&otimes; U+2297
&ouml; U+00F6
&Ouml; U+00D6
&para; U+00B6
&part; U+2202
&permil; U+2030
&perp; U+22A5
&phi; U+03C6
&Phi; U+03A6
&pi; U+03C0
&Pi; U+03A0
&piv; U+03D6
&plusmn; U+00B1
&pound; U+00A3
&prime; U+2032
&Prime; U+2033
&prod; U+220F
&prop; U+221D
&psi; U+03C8
&Psi; U+03A8
&quot; U+0022
&radic; U+221A
&rang; U+232A
&raquo; U+00BB
&rarr; U+2192
&rArr; U+21D2
&rceil; U+2309
&rdquo; U+201D
&real; U+211C
&reg; U+00AE
&rfloor; U+230B
&rho; U+03C1
&Rho; U+03A1
&rlm; U+200F
&rsaquo; U+203A
&rsquo; U+2019
&sbquo; U+201A
&scaron; U+0161
&Scaron; U+0160
&sdot; U+22C5
&sect; U+00A7
&shy; U+00AD
&sigma; U+03C3
&Sigma; U+03A3
&sigmaf; U+03C2
&sim; U+223C
&spades; U+2660
&sub; U+2282
&sube; U+2286
&sum; U+2211
&sup; U+2283
&sup1; U+00B9
&sup2; U+00B2
&sup3; U+00B3
&supe; U+2287
&szlig; U+00DF
&tau; U+03C4
&Tau; U+03A4
&there4; U+2234
&theta; U+03B8
&Theta; U+0398
&thetasym; U+03D1
&thinsp; U+2009
&thorn; U+00FE
&THORN; U+00DE
&tilde; U+02DC
&times; U+00D7
&trade; U+2122
&uacute; U+00FA
&Uacute; U+00DA
&uarr; U+2191
&uArr; U+21D1
&ucirc; U+00FB
&Ucirc; U+00DB
&ugrave; U+00F9
&Ugrave; U+00D9
&uml; U+00A8
&upsih; U+03D2
&upsilon; U+03C5
&Upsilon; U+03A5
&uuml; U+00FC
&Uuml; U+00DC
&weierp; U+2118
&xi; U+03BE
&Xi; U+039E
&yacute; U+00FD
&Yacute; U+00DD
&yen; U+00A5
&yuml; U+00FF
&Yuml; U+0178
&zeta; U+03B6
&Zeta; U+0396
&zwj; U+200D
&zwnj; U+200C

*/


return result;
}



} // Class
