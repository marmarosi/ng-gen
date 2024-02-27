/* 3rd party libraries */

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */

export interface #PascalSingle#Dto {

    name: string;
}

export namespace #PascalSingle#Dto {

  export function create(): #PascalSingle#Dto {
    return {
      name: ''
    };
  }
}