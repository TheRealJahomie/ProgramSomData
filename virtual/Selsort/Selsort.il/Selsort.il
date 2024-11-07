	.method public hidebysig static 
		void SelectionSort (
			int32[] arr 		// The int array
		) cil managed 
	{
		// Method begins at RVA 0x20cc
		// Header size: 12
		// Code size: 78 (0x4e)
		.maxstack 4				// Max stack size
		.locals init (
			[0] int32,			// This is the integer i
			[1] int32,			// Next iteration
			[2] int32,			//...
			[3] int32,			// Last iteration, stops as .maxstack 4	
			[4] bool,			// Comparison arr[j] < arr[least]
			[5] bool,			//...
			[6] bool			//...
		)

		IL_0000: nop			// No operation
		IL_0001: ldc.i4.0		// load local variable, its constant 0
		IL_0002: stloc.0		// store local variable, its 0 in i
		IL_0003: br.s IL_0041	// unconditional jump
		// loop start (head: IL_0041)
			IL_0005: nop		// No operation
			IL_0006: ldloc.0	// Load i onto the stack
			IL_0007: stloc.1	// Store i in least (local variable 1)
			IL_0008: ldloc.0	// load i again onto stack
			IL_0009: ldc.i4.1	// Load constant 1 onto stack
			IL_000a: add		// Increment i 	
			IL_000b: stloc.3	// Store i+1 in j
			IL_000c: br.s IL_0022	// Jump to inner loop
			// loop start (head: IL_0022)
				IL_000e: ldarg.0                   // Load the array onto the stack
				IL_000f: ldloc.3                   // Load j ..
				IL_0010: ldelem.i4                 // Load arr[j] ..
				IL_0011: ldarg.0                   // Load the array onto stack again..
				IL_0012: ldloc.1                   // Load least onto stack
				IL_0013: ldelem.i4                 // Load arr[least] onto the stack
				IL_0014: clt                       // Compare arr[j] < arr[least]
				IL_0016: stloc.s 4                 // Store result
				IL_0018: ldloc.s 4                 // Load local4
				IL_001a: brfalse.s IL_001e         // If arr[j] >= arr[least], skip

				IL_001c: ldloc.3		// Load j
				IL_001d: stloc.1		// Set j 

				IL_001e: ldloc.3		//again load local variable
				IL_001f: ldc.i4.1		//load constant 
				IL_0020: add			//increment 
				IL_0021: stloc.3		// Store new j value in local3

				IL_0022: ldloc.3		//load..
				IL_0023: ldarg.0		//load array
				IL_0024: ldlen			//lenght
				IL_0025: conv.i4		//Convert  
				IL_0026: clt			// Check if j < arr.Length
				IL_0028: stloc.s 5		// Store the result in locals
				IL_002a: ldloc.s 5  	// Load local5 onto the stack 
				IL_002c: brtrue.s IL_000e	//If j < arr.Length, continue
			// end loop

			IL_002e: ldarg.0                   // Load arr onto the stack
			IL_002f: ldloc.0                   // Load i ..
			IL_0030: ldelem.i4                 // Load arr[i] ..
			IL_0031: stloc.2                   // Store arr[i] in local2 (temporary)
			IL_0032: ldarg.0                   // Load array ...
			IL_0033: ldloc.0                   // Load i ..
			IL_0034: ldarg.0                   // Load array onto the stack again
			IL_0035: ldloc.1                   // Load least ..
			IL_0036: ldelem.i4                 // Load arr[least] onto the stack
			IL_0037: stelem.i4                 // Set arr[i] = arr[least]
			IL_0038: ldarg.0                   // Load array ..
			IL_0039: ldloc.1                   // Load least ..
			IL_003a: ldloc.2                   // Load arr[i] from local2 ..
			IL_003b: stelem.i4                 // Set arr[least] = arr[i]
			IL_003c: nop                       // No operation

			IL_003d: ldloc.0                   // Load i onto the stack
			IL_003e: ldc.i4.1                  // Load constant 1 onto the stack
			IL_003f: add                       // Increment i by 1
			IL_0040: stloc.0                   // Store new i in local0

			IL_0041: ldloc.0		// Load local0, which is i
			IL_0042: ldarg.0		// Load array 
			IL_0043: ldlen			// Get length of Array
			IL_0044: conv.i4		// Convert array
			IL_0045: clt			// Checks if i < arr.Length
			IL_0047: stloc.s 6		// store result in local6
			IL_0049: ldloc.s 6		// Load result
			IL_004b: brtrue.s IL_0005	//If true, repeats
		// end loop

		IL_004d: ret					// Return method
	} // end of method Selsort::SelectionSort
