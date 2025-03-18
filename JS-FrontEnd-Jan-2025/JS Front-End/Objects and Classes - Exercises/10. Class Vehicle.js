class Vehicle {
    type;
    model;
    parts = {};
    fuel;

    constructor(type, model, parts, fuel) {
        this.type = type;
        this.model = model;
        this.parts.engine = parts.engine;
        this.parts.power = parts.power;
        this.parts.quality = parts.engine * parts.power;
        this.fuel = fuel;
    }

    drive(fuelSpent) {
        this.fuel -= fuelSpent;
    }
}
