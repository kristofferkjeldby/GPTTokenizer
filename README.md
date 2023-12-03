# GTPTokenizer
A GPT-3.5/GTP-4 compatible tokenizer

To see how to use the tokenizer, check the "test" project GTPTokenizer.Console.

```
GPTTokenizer.Console.exe "Conveyor Conveyor Conveyor"

|C|o|n|v|e|y|o|r|G|C|o|n|v|e|y|o|r|G|C|o|n|v|e|y|o|r|
|C|on|v|e|y|o|r|G|C|o|n|v|e|y|o|r|G|C|o|n|v|e|y|o|r| ← Applied merge rule #8 (o n)
|C|on|v|e|y|o|r|G|C|on|v|e|y|o|r|G|C|o|n|v|e|y|o|r| ← Applied merge rule #8 (o n)
|C|on|v|e|y|o|r|G|C|on|v|e|y|o|r|G|C|on|v|e|y|o|r| ← Applied merge rule #8 (o n)
|C|on|v|e|y|or|G|C|on|v|e|y|o|r|G|C|on|v|e|y|o|r| ← Applied merge rule #14 (o r)
|C|on|v|e|y|or|G|C|on|v|e|y|or|G|C|on|v|e|y|o|r| ← Applied merge rule #14 (o r)
|C|on|v|e|y|or|G|C|on|v|e|y|or|G|C|on|v|e|y|or| ← Applied merge rule #14 (o r)
|C|on|v|e|y|or|GC|on|v|e|y|or|G|C|on|v|e|y|or| ← Applied merge rule #101 (G C)
|C|on|v|e|y|or|GC|on|v|e|y|or|GC|on|v|e|y|or| ← Applied merge rule #101 (G C)
|C|on|ve|y|or|GC|on|v|e|y|or|GC|on|v|e|y|or| ← Applied merge rule #333 (v e)
|C|on|ve|y|or|GC|on|ve|y|or|GC|on|v|e|y|or| ← Applied merge rule #333 (v e)
|C|on|ve|y|or|GC|on|ve|y|or|GC|on|ve|y|or| ← Applied merge rule #333 (v e)
|Con|ve|y|or|GC|on|ve|y|or|GC|on|ve|y|or| ← Applied merge rule #873 (C on)
|Con|ve|y|or|GCon|ve|y|or|GC|on|ve|y|or| ← Applied merge rule #966 (GC on)
|Con|ve|y|or|GCon|ve|y|or|GCon|ve|y|or| ← Applied merge rule #966 (GC on)
|Con|vey|or|GCon|ve|y|or|GCon|ve|y|or| ← Applied merge rule #5480 (ve y)
|Con|vey|or|GCon|vey|or|GCon|ve|y|or| ← Applied merge rule #5480 (ve y)
|Con|vey|or|GCon|vey|or|GCon|vey|or| ← Applied merge rule #5480 (ve y)
|Con|veyor|GCon|vey|or|GCon|vey|or| ← Applied merge rule #69714 (vey or)
|Con|veyor|GCon|veyor|GCon|vey|or| ← Applied merge rule #69714 (vey or)
|Con|veyor|GCon|veyor|GCon|veyor| ← Applied merge rule #69714 (vey or)
|Con|veyor|GConveyor|GCon|veyor| ← Applied merge rule #100001 (GCon veyor)
|Con|veyor|GConveyor|GConveyor| ← Applied merge rule #100001 (GCon veyor)

IDs: [1128, 69969, 100255, 100255]
```

```
GPTTokenizer.Console.exe "Saturn is the sixth planet from the Sun."

|S|a|t|u|r|n|G|i|s|G|t|h|e|G|s|i|x|t|h|G|p|l|a|n|e|t|G|f|r|o|m|G|t|h|e|G|S|u|n|.|
|S|a|t|u|r|n|G|i|s|Gt|h|e|G|s|i|x|t|h|G|p|l|a|n|e|t|G|f|r|o|m|G|t|h|e|G|S|u|n|.| ← Applied merge rule #4 (G t)
|S|a|t|u|r|n|G|i|s|Gt|h|e|G|s|i|x|t|h|G|p|l|a|n|e|t|G|f|r|o|m|Gt|h|e|G|S|u|n|.| ← Applied merge rule #4 (G t)
|S|at|u|r|n|G|i|s|Gt|h|e|G|s|i|x|t|h|G|p|l|a|n|e|t|G|f|r|o|m|Gt|h|e|G|S|u|n|.| ← Applied merge rule #11 (a t)
|S|at|u|r|n|G|i|s|Gth|e|G|s|i|x|t|h|G|p|l|a|n|e|t|G|f|r|o|m|Gt|h|e|G|S|u|n|.| ← Applied merge rule #15 (Gt h)
|S|at|u|r|n|G|i|s|Gth|e|G|s|i|x|t|h|G|p|l|a|n|e|t|G|f|r|o|m|Gth|e|G|S|u|n|.| ← Applied merge rule #15 (Gt h)
|S|at|u|r|n|G|i|s|Gth|e|Gs|i|x|t|h|G|p|l|a|n|e|t|G|f|r|o|m|Gth|e|G|S|u|n|.| ← Applied merge rule #19 (G s)
|S|at|u|r|n|G|i|s|Gth|e|Gs|i|x|t|h|G|p|l|an|e|t|G|f|r|o|m|Gth|e|G|S|u|n|.| ← Applied merge rule #21 (a n)
|S|at|u|r|n|G|i|s|Gthe|Gs|i|x|t|h|G|p|l|an|e|t|G|f|r|o|m|Gth|e|G|S|u|n|.| ← Applied merge rule #24 (Gth e)
|S|at|u|r|n|G|i|s|Gthe|Gs|i|x|t|h|G|p|l|an|e|t|G|f|r|o|m|Gthe|G|S|u|n|.| ← Applied merge rule #24 (Gth e)
|S|at|u|r|n|G|i|s|Gthe|Gs|i|x|t|h|Gp|l|an|e|t|G|f|r|o|m|Gthe|G|S|u|n|.| ← Applied merge rule #26 (G p)
|S|at|u|r|n|G|i|s|Gthe|Gs|i|x|t|h|Gp|l|an|e|t|Gf|r|o|m|Gthe|G|S|u|n|.| ← Applied merge rule #27 (G f)
|S|at|u|r|n|G|is|Gthe|Gs|i|x|t|h|Gp|l|an|e|t|Gf|r|o|m|Gthe|G|S|u|n|.| ← Applied merge rule #30 (i s)
|S|at|u|r|n|G|is|Gthe|Gs|i|x|t|h|Gp|l|an|et|Gf|r|o|m|Gthe|G|S|u|n|.| ← Applied merge rule #40 (e t)
|S|at|u|r|n|G|is|Gthe|Gs|i|x|t|h|Gp|l|an|et|Gf|ro|m|Gthe|G|S|u|n|.| ← Applied merge rule #44 (r o)
|S|at|ur|n|G|is|Gthe|Gs|i|x|t|h|Gp|l|an|et|Gf|ro|m|Gthe|G|S|u|n|.| ← Applied merge rule #69 (u r)
|S|at|ur|n|G|is|Gthe|Gs|i|x|t|h|Gp|l|an|et|Gf|ro|m|Gthe|GS|u|n|.| ← Applied merge rule #73 (G S)
|S|at|ur|n|G|is|Gthe|Gs|i|x|th|Gp|l|an|et|Gf|ro|m|Gthe|GS|u|n|.| ← Applied merge rule #84 (t h)
|S|at|ur|n|G|is|Gthe|Gs|i|x|th|Gp|l|an|et|Gf|ro|m|Gthe|GS|un|.| ← Applied merge rule #104 (u n)
|S|at|ur|n|Gis|Gthe|Gs|i|x|th|Gp|l|an|et|Gf|ro|m|Gthe|GS|un|.| ← Applied merge rule #119 (G is)
|S|at|urn|Gis|Gthe|Gs|i|x|th|Gp|l|an|et|Gf|ro|m|Gthe|GS|un|.| ← Applied merge rule #144 (ur n)
|S|at|urn|Gis|Gthe|Gs|i|x|th|Gp|l|an|et|Gf|rom|Gthe|GS|un|.| ← Applied merge rule #187 (ro m)
|S|at|urn|Gis|Gthe|Gs|i|x|th|Gp|l|an|et|Gfrom|Gthe|GS|un|.| ← Applied merge rule #250 (Gf rom)
|S|at|urn|Gis|Gthe|Gs|i|x|th|Gpl|an|et|Gfrom|Gthe|GS|un|.| ← Applied merge rule #373 (Gp l)
|S|at|urn|Gis|Gthe|Gs|ix|th|Gpl|an|et|Gfrom|Gthe|GS|un|.| ← Applied merge rule #698 (i x)
|S|at|urn|Gis|Gthe|Gs|ix|th|Gplan|et|Gfrom|Gthe|GS|un|.| ← Applied merge rule #2942 (Gpl an)
|S|at|urn|Gis|Gthe|Gsix|th|Gplan|et|Gfrom|Gthe|GS|un|.| ← Applied merge rule #4593 (Gs ix)
|S|at|urn|Gis|Gthe|Gsix|th|Gplan|et|Gfrom|Gthe|GSun|.| ← Applied merge rule #7964 (GS un)
|S|at|urn|Gis|Gthe|Gsix|th|Gplanet|Gfrom|Gthe|GSun|.| ← Applied merge rule #11586 (Gplan et)
|S|at|urn|Gis|Gthe|Gsixth|Gplanet|Gfrom|Gthe|GSun|.| ← Applied merge rule #25829 (Gsix th)
|Sat|urn|Gis|Gthe|Gsixth|Gplanet|Gfrom|Gthe|GSun|.| ← Applied merge rule #35727 (S at)

IDs: [35982, 399, 374, 279, 26084, 11841, 505, 279, 8219, 13]
```
