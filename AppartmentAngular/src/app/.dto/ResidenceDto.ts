import {ImageDto} from './ImageDto'


export interface ResidenceDto {
  Name: string,
  Bathrooms: number,
  Toilets: number,
  Bedrooms: number,
  SwimmingPool: boolean,
  Wifi: boolean,
  Breakfast: boolean,
  Kitchen: boolean,
  Television: boolean,
  NearbyBeach: boolean,
  NearbyCity: boolean,
  NearbySubway: boolean,
  NearbyTrainStation: boolean,
  ResidenceType: number,
  Summary: string
  Pictures: ImageDto[]
}
