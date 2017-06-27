# HyperionContainerSerialisation
Demonstrate an issue I am having with the current versions of the Hyperion serialiser when used to return an enumerable of some type. If the type being serialised is a class then it seems to work without issue, but if it an implementation of a generic interface then (I believe) it doesn't serialise the type information correctly.
