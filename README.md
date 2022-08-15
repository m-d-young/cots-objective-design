# README

## introduction

This repository contains files related to the SPIE optical engineering
manuscript ***Global design of an off-the-shelf objective lens with no a priori
design and macro-enabled optimization***. Included are files to support the
presented graphics. The files can be opened in Zemax OpticStudio. They are saved
in the legacy zmx file extension, which is plain text.

## folder contents

-   COTS-0002-01-0.zmx
    -   The initial generic lens design.
    -   This file produces Fig. 1.
    -   The merit function is for the general solution, i.e., not stock lenses.
    -   The merit function is included in the file.
    -   To reproduce a general solution, execute the global search optimization
        feature.
-   COTS-0002-02-1.zmx
    -   The general solution without stock shape factors. There is no constraint
        on the shape factor of the lenses. 
    -   This file produces Fig. 2 (Layout).
    -   This file produces Fig. 5 (MTF).
-   COTS-0002-04-1.zmx
    -   The solution with stock shape factors. This design was found using the
        **SHAPE-FACTOR.ZPL** optimization macro. This macro constructs a merit
        function which constraints the shape of the lenses to a stock shape
        factor.
    -   This file produces Fig. 3.
-   COTS-0002-12-1.zmx
    -   The solution with off-the-shelf substitutions. This design proceeds from
        4-1 and substitutes COTS lenses into the design.
    -   This file produces Fig. 4 (Layout).
    -   This file produces Fig. 5 (MTF).
    -   This file produces Fig. 7 (Yield).
-   SHAPE-FACTOR.ZPL
    -   This macro will construct the merit function for stock shape factor
        optimization.
-   ZPL01.ZPL
    -   This macro is for use with the ZPLM merit function operand. It is
        capable of optimizing toward stock shape factors. Use of the ZPLM will
        restrict Zemax OpticStudio to single core performance.
-   Program.cs
    -   The c# code for generating the executable related to the use of UDOC
        operand. See the [Zemax help
        file](https://support.zemax.com/hc/en-us/articles/1500005490081-How-to-create-a-User-Operand-using-ZOS-API).
-   UDOC02.exe
    -   c# compiled executable to be used with UDOC for the optimization of
        shape factor for two surfaces. 
    -   __The author recommends against using
        this executable__. It performs the same function as the ZPL01.ZPL macro;
        however, it has caused instability in the author's computer resulting in
        computer crashes. 
    -   See the license for information on use of the this and any software in
        the repository.
-   LICENSE
    -   MIT license

## change log

-   2022-08-12:
    -   creation of the README.md file
    -   (archived) old zmx files related to previous version of the manuscript.
    -   addition of the cs and exe files related to UDOC operand optimization
-   2022-08-15
    -   addition of figure references to manuscript for each zmx file.
