using CSharp10.Linq.Contained;

// Create instance of view model
SamplesViewModel vm = new();

// Call Sample Method
var result = vm.ContainsCompareMethod();

// Display Results
vm.Display(result);