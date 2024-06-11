import { Terrain } from "./Terrain";
import { WeatherAudit } from "./WeatherAudit";

export interface SimEnvironment{
    weatherHistory: WeatherAudit;
    terrain: Array<Array<Terrain>>;
    turnCount: number;
}