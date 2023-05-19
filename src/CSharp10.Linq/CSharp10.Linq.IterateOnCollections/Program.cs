using CSharp10.Linq.IterateOnCollections;

SamplesViewModel vm = new();

// Call Sample Method
var result = vm.ForEachQueryCallingMethod();

// Display Results
vm.Display(result);