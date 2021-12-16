import {ImageDto} from './ImageDto'


export interface ResidenceDto {
  name: string,
  bathrooms: number,
  toilets: number,
  bedrooms: number,
  swimmingPool: boolean,
  wifi: boolean,
  breakfast: boolean,
  kitchen: boolean,
  television: boolean,
  nearbyBeach: boolean,
  nearbyCity: boolean,
  nearbySubway: boolean,
  nearbyTrainStation: boolean,
  residenceType: number,
  summary: string
  pictures: ImageDto[]
}
