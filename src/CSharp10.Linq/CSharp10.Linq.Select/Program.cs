

// Create instance of view model
using CSharp10.Linq.Select;

SamplesViewModel vm = new();

// Call Sample Method
var result = vm.AnonymousClassQuery();

// Display Results
vm.Display(result);