# Simulador-Ingresos-Petroleo-CSharp
# Oil Revenue Simulation (C#)

## Description
This project is a C# console application that simulates oil revenue growth under two different economic scenarios:
- Scenario A: Growth without external intervention
- Scenario B: Growth with progressive external intervention

The program analyzes how economic restrictions affect long-term revenue.

---

## Features
- User input validation (integers and decimals)
- Simulation of revenue growth over multiple periods
- Mathematical model for progressive reduction of growth rate
- Comparison between two economic scenarios
- Detection of maximum revenue limit
- Detection of economic stagnation

---

## Technologies
- C#
- .NET
- Console Application

---

## Concepts Applied
- Object-Oriented Programming (OOP)
- Separation of concerns
- Modular programming (functions and procedures)
- Mathematical modeling
- Input validation
- Control structures (loops and conditionals)

---

## How It Works
The user provides:
- Initial revenue
- Growth rate
- Number of periods
- Maximum revenue limit

The system simulates:

### Scenario A
Constant growth:
Revenue(n) = Revenue(n-1) × Rate

### Scenario B
Progressive reduction of growth:
Growth(n) = (Rate - 1.0) × 0.80^(n-1)

The simulation stops when:
- The revenue reaches the maximum limit
- The growth rate reaches stagnation

---

## Example Output
Scenario A:
Period 1: Revenue = 10,000
Period 2: Revenue = 12,500
...

Scenario B:
Period 1: Revenue = 10,000 (rate: 1.25)
Period 2: Revenue = 12,000 (rate: 1.20)
...

---

## Author
Aarón David Guerrero Velázquez
