// Global variable to store the .NET object reference
let dotNetReference = null;

// Buffer to accumulate scanned characters
let scanBuffer = '';

// Timeout to detect end of scan
let scanTimeout;

// Function to handle keydown events
function scannerKeydownHandler(e) {
    // Check if the input is coming from a text input field
    if (e.target.tagName === 'INPUT' && e.target.type === 'text') {
        return; // Allow normal typing in text fields
    }

    // Prevent default action for all keys except Enter
    if (e.key !== 'Enter') {
        e.preventDefault();
    }

    // Clear timeout and reset buffer on Enter key
    if (e.key === 'Enter') {
        clearTimeout(scanTimeout);
        if (scanBuffer.length > 0) {
            dotNetReference.invokeMethodAsync('OnScanComplete', scanBuffer);
            scanBuffer = '';
        }
    } else {
        // Add character to buffer
        scanBuffer += e.key;

        // Set a timeout to clear the buffer if no new input is received
        clearTimeout(scanTimeout);
        scanTimeout = setTimeout(function () {
            scanBuffer = '';
        }, 100); // Adjust this value based on your scanner's behavior
    }
}

// Function to set up the scanner
window.setupScanner = function (reference) {
    dotNetReference = reference;
    document.addEventListener('keydown', scannerKeydownHandler);
};

// Function to dispose of the scanner setup
window.disposeScanner = function () {
    document.removeEventListener('keydown', scannerKeydownHandler);
    dotNetReference = null;
};

// Optional: Function to manually trigger a scan (useful for testing)
window.triggerScan = function (scanData) {
    if (dotNetReference) {
        dotNetReference.invokeMethodAsync('OnScanComplete', scanData);
    } else {
        console.error('Blazor reference not set. Make sure setupScanner has been called.');
    }
};