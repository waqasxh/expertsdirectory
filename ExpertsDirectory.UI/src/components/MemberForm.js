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
      />
      <TextInput
        id="email"
        label="Email"
        name="email"
        onChange={props.onChange}
        value={props.member.email}
        error={props.errors.email}
      />
      <TextInput
        id="website"
        label="Website"
        name="website"
        onChange={props.onChange}
        value={props.member.website}
        error={props.errors.website}
      />

      <input type="submit" value="Save" className="btn btn-primary" />
      <Link className="btn btn-primary button2" to="/members">
        Back
      </Link>
    </form>
  );
}

MemberForm.propTypes = {
  member: PropTypes.object.isRequired,
  onSubmit: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  errors: PropTypes.object.isRequired
};

export default MemberForm;
