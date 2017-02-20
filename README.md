# maybe
`Maybe<T>` is a simplistic implementation of an option type, much like [`Optional` in Java](https://docs.oracle.com/javase/8/docs/api/java/util/Optional.html).

While option types for value types are supported natively in the BCL through `Nullable<T>`, there is currently no equivalent for reference types. This (very small) library aims to complement the BCL by providing such a type, allowing developers to handle `null` values more succinctly - namely through `Maybe<T>.NoValue`.

Maybe's implementation is contained in a single `struct`.

# example
Constructing an option type can be done in several different ways. The first, and most obvious, is simply `new`-ing an instance:

```csharp
    var maybe = new Maybe<string>("hello");
```
    
However, we can also let the compiler infer the type argument for us, through the use of the various `Of` methods:

```csharp
    var maybe = Maybe.Of("hello");
```

If we're unsure whether the value we're passing to `Of` is `null` or not, you can also use `OfNullableReferenceType`, since `Of` will throw an `ArgumentNullException` if its value argument is null.

Whichever way we choose to construct the `Maybe<T>` instance with, we can always check whether it has a value with `maybe.HasValue`, and retrieve its value with `maybe.Value`, if it contains one. Note that if `maybe.Value` is called on an instance which doesn't contain a value, an `InvalidOperationException` will be thrown, since there is no sensible way to handle that case without exposing `null` (which is what we're trying to prevent here in the first place).

# value types
For the sake of consistency, it could be desirable to wrap value types in an option type. While this is supported, do keep in mind that `Maybe<T>` does not get the same special treatment `Nullable<T>` gets - i.e. `Maybe<T>` **can** be boxed, whereas `Nullable<T>` will never get boxed. 

To create a `Maybe<T>` instance from either a value type or a `Nullable<T>`, you can use something along the lines of:

```csharp
    var maybe = Maybe.OfValueType(Guid.Empty);
```

# contributions
Questions and contributions are very much welcome. When submitting a pull request, please make sure it is accompanied by an issue on the [issue tracker](https://github.com/aevitas/maybe/issues), and if a non-trivial change, have been discussed prior to putting in the effort. 

When contributing code, please try and adhere to the coding style already present as much as possible. If you are unsure what coding style that is, it is fairly close to the [.NET Core coding style](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md).
