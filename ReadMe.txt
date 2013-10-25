Does your project contain classes that implement IClonable? 

Then you might agree that it is not entirely unlikely that when people add a member,
(to a class that implements IClonable) they forget to add the cloning of that property in the clone method.

This little automatic tester scans your assemblies for types IClonable types and 
check if all members are cloned properly (If you havent chosen to ignore them).

I will at some point add theequivalent for IComparable etc.

There might be types/scenarios I havent covered so feel free to contribute or let me know at:

mojjen@gmail.com


kind regards,
Magnus Ahlin

Please download my iPhone app PriceJackr.com when it gets released :)


