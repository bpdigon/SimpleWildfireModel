// import { LightningEvent } from "./LightningEvent";
// import { RainEvent } from "./RainEvent";
// import { WindEvent } from "./WindEvent";

// export class WeatherAudit{
//     lightningEvents?: Array<LightningEvent> = [];
//     windEvents?: Array<WindEvent> = [];
//     rainEvents?: Array<RainEvent> = [];

//     // constructor(light: Array<LightningEvent>, wind: Array<WindEvent>, rain: Array<RainEvent>){

//     //     this.lightningEvents = light;
//     //     this.windEvents = wind;
//     //     this.rainEvents = rain;
//     // }
//     constructor(){}
// }

import { LightningEvent } from "./LightningEvent";
import { RainEvent } from "./RainEvent";
import { WindEvent } from "./WindEvent";

export interface WeatherAudit{
    lightningEvent?: Array<LightningEvent>;
    windEvents?: Array<WindEvent>;
    rainEvents?: Array<RainEvent>;

    // constructor(light: Array<LightningEvent>, wind: Array<WindEvent>, rain: Array<RainEvent>){

    //     this.lightningEvents = light;
    //     this.windEvents = wind;
    //     this.rainEvents = rain;
    // }
}