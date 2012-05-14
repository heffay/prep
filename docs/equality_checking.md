#Rules for Framework Equality Checking

1. Is it a class (reference type)
  - Does it implement IEquatable<T> - use it
  - Does it override Equals - use it
  - Reference based equality check

2. Is it a struct (value type)
  - Does it override Equals - use it
  - Reflective field by field
