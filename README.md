# refactoring-with-aop

[Lviv .NET User Group presentation] Refactoring cross-cutting concerns in a .NET application using two approaches: traditional OOP and AOP (PostSharp).

## How to use

Follow the commit graph to understand the refactoring steps: `git log --graph --oneline --decorate --all`

* `git checkout v0.1-before-refactoring`: messy code with cross-cutting concerns scattered throughout the methods.
* `git checkout v0.2-oop-refactoring`: attempt to refactor the cross-cutting concerns using simple OOP techniques.
* `git checkout v0.3-aop-refactoring`: attempt to refactor the cross-cutting concerns using aspect-oriented programming and the PostSharp framework.
