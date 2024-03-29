/* 3rd party libraries */
import { required, maxLength, prop } from '@rxweb/reactive-form-validators';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */

const msgRoot = '#camelPlural#.#camelIndex#.';

export class #PascalIndex# {

  public modelId?: string;

  @required( { message: msgRoot + 'name.required' } )
  @maxLength( { value: 100, message: msgRoot + 'name.maxLength' } )
  public name: string = '';

  public timestamp?: Date;

  constructor( data: any ) {
    Object.assign( this, data );
  }
}
