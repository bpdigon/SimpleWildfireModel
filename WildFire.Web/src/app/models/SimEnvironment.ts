import { Terrain } from "./Terrain";
import { TerrainList } from "./TerrainList";
import { WeatherAudit } from "./WeatherAudit";

export class SimEnvironment{
    WeatherHistory?: WeatherAudit;
    Terrain: TerrainList[] = [];
    TurnCount?: number;
    // constructor(weatherHistory: WeatherAudit, terrain: Terrain[][], turnCount: number){
    //     this.weatherHistory = weatherHistory;
    //     this.terrain = terrain;
    //     this.turnCount = turnCount;
    // }
}