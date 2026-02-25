const display = document.getElementById('display');

// Append number or operator to the display
const appendToDisplay = (value) => {
    display.value += value;
}

// Clear the display
const clearDisplay = () => {
    display.value = '';
}

// Calculate the result
const calculateResult = () => {
    try {
        const result = eval(display.value);
        display.value = result;
    }
    catch (error) {
        display.value = 'Error';
    }
};
