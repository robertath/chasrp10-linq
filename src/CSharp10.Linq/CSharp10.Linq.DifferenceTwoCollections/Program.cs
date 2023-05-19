using CSharp10.Linq.DifferenceTwoCollections;

// Create instance of view model
SamplesViewModel vm = new();

// Call Method
var result = vm.IntersectByProductSalesQuery();

// Display Results
vm.Display(result);