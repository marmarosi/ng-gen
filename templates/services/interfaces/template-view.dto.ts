/* 3rd party libraries */

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */

export interface #PascalSingle#ViewDto {

    name: string;
}

export namespace #PascalSingle#ViewDto {

  export function create(): #PascalSingle#ViewDto {
    return {
      name: ''
    };
  }
}