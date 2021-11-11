import React from "react";
import TextInput from "./common/TextInput";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

function MemberForm(props) {
  return (
    <form onSubmit={props.onSubmit}>
      <TextInput
        id="name"
        label="Name"
        name="name"
        onChange={props.onChange}
        value={props.member.name}
        error={props.errors.name}
        disabled={props.member.id ? true : false}
      />
      <TextInput
        id="email"
        label="Email"
        name="email"
        onChange={props.onChange}
        value={props.member.email}
        error={props.errors.email}
        disabled={props.member.id ? true : false}
      />
      <TextInput
        id="website"
        label="Website"
        name="website"
        onChange={props.onChange}
        value={props.member.website}
        error={props.errors.website}
        disabled={props.member.id ? true : false}
      />
      {props.member.id !== 0 && props.member.friends.length > 0 && <div>
        <label htmlFor="Friends">Friends (Click on friend's name to visit their website)</label>

        <div className="friendsList">
          {props.member.friends && props.member.friends.map(friend => {
            return <a href={friend.website} target="_blank" rel="noopener" > {friend.name}  </a>
          })}
        </div>
      </div>}
      <input type="submit" disabled={props.member.id ? true : false} value="Save" className="btn btn-primary" />
      <Link className="btn btn-primary button2" to="/members">
        Back
      </Link>
    </form>
  );
}

MemberForm.propTypes = {
  member: PropTypes.object.isRequired,
  onSubmit: PropTypes.func.isRequired,
  onSearch: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  errors: PropTypes.object.isRequired
};

export default MemberForm;
