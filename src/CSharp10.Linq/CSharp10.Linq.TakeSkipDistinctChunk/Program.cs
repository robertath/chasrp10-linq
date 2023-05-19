using CSharp10.Linq.TakeSkipDistinctChunk;

// Create instance of view model
SamplesViewModel vm = new();

// Call Sample Method
var result = vm.ChunkMethod();

// Display Results
vm.Display(result);