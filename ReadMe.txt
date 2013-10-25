Does your project contain classes that implement ICloneable? 

Then you might agree that it is not entirely unlikely that when people add a member,
(to a class that implements ICloneable) they forget to add the cloning of that property in the clone method.

This little automatic tester scans your assemblies for types ICloneable types and 
check if all members are cloned properly (If you haven't chosen to ignore them).

I will at some point add the equivalent for IComparable etc.

There might be types/scenarios I haven't covered so feel free to contribute or let me know at:

mojjen@gmail.com


kind regards,
Magnus Ahlin

Please download my iPhone app PriceJackr.com when it gets released :)


