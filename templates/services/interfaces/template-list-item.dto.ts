/* 3rd party libraries */

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */

export interface #PascalSingle#ListItemDto {

    name: string;
}

export namespace #PascalSingle#ListItemDto {

  export function create(): #PascalSingle#ListItemDto {
    return {
      name: ''
    };
  }
}