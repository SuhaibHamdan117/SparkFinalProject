import { Field, useFormik } from "formik";
import React, { useContext, useState } from "react";
import { Marginer } from "../marginer";
import {
    BoldLink,
    BoxContainer,
    FieldContainer,
    FieldError,
    FormContainer,
    FormSuccess,
    Input,
    MutedLink,
    SubmitButton,
    FormError,
} from "./common";
import { AccountContext } from "./accountContext";
import * as yup from "yup";
import axios from "axios";

const PASSWORD_REGEX = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/;

const validationSchema = yup.object({
    firstName: yup
        .string()
        .min(3, "Please enter a real name")
        .required("First name is required!"),
    lastName: yup
        .string()
        .min(3, "Please enter a real name")
        .required("First name is required!"),
  
    password: yup
        .string()
        .matches(PASSWORD_REGEX, "Please enter a strong password")
        .required(),
    confirmPassword: yup
        .string()
        .required("Please confirm your password")
        .when("password", {
            is: (val) => (val && val.length > 0 ? true : false),
            then: yup
                .string()
                .oneOf([yup.ref("password")], "Password does not match"),
        }),
    email: yup.string().email("Please enter a valid email address").required(),
    Category: yup
        .string()
        .min(3, "Please enter a Category")
        .required("Category is required!"),
});

export function SignupFormT(props) {
    const { switchToSigninT } = useContext(AccountContext);
    const [success, setSuccess] = useState(null);
    const [error, setError] = useState(null);

    const onSubmit = async (values) => {
        const { confirmPassword, ...data } = values;

        const response = await axios
            .post("http://localhost:5555/Account/RegisterTeacher", data)
            .catch((err) => {
                if (err && err.response) setError(err.response.data.message);
                setSuccess(null);
            });

        if (response && response.data) {
            setError(null);
            setSuccess(response.data.message);
            formik.resetForm();
        }
    };

    const formik = useFormik({
        initialValues: {
            firstName: "",
            lastName: "",
            password: "",
            confirmPassword: "",
            email: "",
            Category: "",
        },
        validateOnBlur: true,
        onSubmit,
        validationSchema: validationSchema,
    });
    console.log("Error", error);

    return (
        <BoxContainer>
            {!error && <FormSuccess>{success ? success : ""}</FormSuccess>}
            {!success && <FormError>{error ? error : ""}</FormError>}
            <FormContainer onSubmit={formik.handleSubmit}>
                <FieldContainer>
                    <Input
                        name="firstName"
                        placeholder="First Name"
                        value={formik.values.firstName}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                    />
                    <FieldError>
                        {formik.touched.firstName && formik.errors.firstName
                            ? formik.errors.firstName
                            : ""}
                    </FieldError>
                </FieldContainer>
                <FieldContainer>
                    <Input
                        name="lastName"
                        placeholder="Last Name"
                        value={formik.values.lastName}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                    />
                    <FieldError>
                        {formik.touched.lastName && formik.errors.lastName
                            ? formik.errors.lastName
                            : ""}
                    </FieldError>
                </FieldContainer>
         
                <FieldContainer>
                    <Input
                        name="password"
                        type="password"
                        placeholder="Password"
                        value={formik.values.password}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                    />
                    <FieldError>
                        {formik.touched.password && formik.errors.password
                            ? formik.errors.password
                            : ""}
                    </FieldError>
                </FieldContainer>
                <FieldContainer>
                    <Input
                        name="confirmPassword"
                        type="password"
                        placeholder="Confirm Password"
                        value={formik.values.confirmPassword}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                    />
                    <FieldError>
                        {formik.touched.confirmPassword && formik.errors.confirmPassword
                            ? formik.errors.confirmPassword
                            : ""}
                    </FieldError>
                </FieldContainer>
                <FieldContainer>
                    <Input
                        name="email"
                        placeholder="Email"
                        value={formik.values.email}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                    />
                    <FieldError>
                        {formik.touched.email && formik.errors.email
                            ? formik.errors.email
                            : ""}
                    </FieldError>
                </FieldContainer>
                <FieldContainer>
                    <Input
                        name="Category"
                        placeholder="Category:Math,Physics,Calculas"
                        value={formik.values.Category}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                    />
                    <FieldError>
                        {formik.touched.Category && formik.errors.Category
                            ? formik.errors.Category
                            : ""}
                    </FieldError>
                </FieldContainer>
                <Marginer direction="vertical" margin="1em" />
                <SubmitButton type="submit" disabled={!formik.isValid} onClick={switchToSigninT}>
                    Signup
        </SubmitButton>
            </FormContainer>
            <Marginer direction="vertical" margin={5} />
            <MutedLink href="#">
                Already have an account?
        <BoldLink href="#" onClick={switchToSigninT}>
                    sign in
        </BoldLink>
            </MutedLink>
        </BoxContainer>
    );
}