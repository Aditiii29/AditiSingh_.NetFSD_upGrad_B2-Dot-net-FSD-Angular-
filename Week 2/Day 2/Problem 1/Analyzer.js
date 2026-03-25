// ===================== DATA =====================

const marks = [78, 85, 62, 90, 55]; // student marks


// ===================== CALCULATIONS =====================

// Total using reduce()
const calculateTotal = (arr) =>
    arr.reduce((sum, mark) => sum + mark, 0);


// Average using total
const calculateAverage = (arr) => {
    const total = calculateTotal(arr);
    return total / arr.length;
};


// Pass/Fail based on average
const getResult = (average) =>
    average >= 40 ? "PASS ✅" : "FAIL ❌";


// Optional: Add grace marks using map()
const addGraceMarks = (arr) =>
    arr.map(mark => mark + 2);


// ===================== EXECUTION =====================

const totalMarks = calculateTotal(marks);
const averageMarks = calculateAverage(marks);
const result = getResult(averageMarks);
const updatedMarks = addGraceMarks(marks);


// ===================== DISPLAY =====================

const outputDiv = document.getElementById("output");

outputDiv.innerHTML = `
    <p><strong>Original Marks:</strong> ${marks.join(", ")}</p>
    <p><strong>Total Marks:</strong> ${totalMarks}</p>
    <p><strong>Average Marks:</strong> ${averageMarks.toFixed(2)}</p>
    <p><strong>Result:</strong> ${result}</p>
    <p><strong>Marks After Grace (+2 each):</strong> ${updatedMarks.join(", ")}</p>
`;