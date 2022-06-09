/**
 * Reaction class.
 */
export class Reaction {

  /**
   * Reaction identifier.
   */
  id: string;

  /**
   * Reaction graph identifier.
   */
  reactionId: string;

  /**
   * Reaction value.
   */
  value: Number;

  /**
   * Initializes a new instance of the Reaction class.
   * @param id Reaction identifier.
   * @param reactionId Reaction graph identifier.
   * @param value Value of the reaction.
   */
  constructor(id: string, reactionId: string, value: Number) {
    this.id = id;
    this.reactionId = reactionId;
    this.value = value;
  }
}
