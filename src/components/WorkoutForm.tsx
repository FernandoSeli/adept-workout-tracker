import React from 'react';
import { Button, TextInput, View, Text, Alert } from 'react-native';
import { Form, Formik, useFormikContext } from 'formik';
import * as firebase from 'firebase';
import style from '../styles/Styles';
import { gray } from '../styles/Styles';
import { TouchableHighlight } from 'react-native-gesture-handler';

interface FormValues { //Might want to put on a separate file later on.
    //Also Formik only accepts String. Please make sure you store the data as number.
    key: number;
    name: string;
    reps: string; //Reps and sets should be number, if possible.
    sets: string;
    weight: string; //default in kgs.
    rest: string; //in seconds
}

var data = [];

// const WorkoutForm: React.FC<{}> = props => {
const WorkoutForm = (props: any) => {

    let itemData = props.itemData
    let onChange = props.onChange

    const submit = (formData: object) => {
        // console.log("Updated row data.");
        onChange(formData);
    }

    const validate = (formData: object) => {
        // Do everytime onChangeText
        let inputTimer: any
        var duration = 150;
        clearTimeout(inputTimer)
        inputTimer = setTimeout(() => {
            submit(formData)
        }, duration);
        // submit(formData);
    }

    if (props.itemData) {
        // Data check
        // console.log("Item data is present: ")
        // console.log(props.itemData)
    }

    // const initialValues: FormValues = {
    //     key: itemData.key,
    //     name: itemData.name,
    //     reps: itemData.reps,
    //     sets: itemData.sets,
    //     weight: itemData.weight,
    //     rest: itemData.rest,
    // }

    return (
        <Formik
            initialValues={itemData}
            onSubmit={values => submit(values)}
            validate={values => validate(values)}
        >
            {({ handleChange, handleBlur, handleSubmit, values }) => (
                <View style={style.card}>
                    <View style={style.formRow}> 
                        <Text style={style.inputLabel}>Name</Text>
                        <TextInput
                            onChangeText={handleChange('name')}
                            onBlur={handleBlur('name')}
                            value={values.name}
                            style={style.inputBox}
                            placeholder="Workout Name" placeholderTextColor={gray}
                            keyboardAppearance="dark"
                        />
                    </View>
                    <View style={style.formRow}>
                        <Text style={style.inputLabel}>Weight</Text>
                        <TextInput
                            onChangeText={handleChange('weight')}
                            onBlur={handleBlur('weight')}
                            value={values.weight}
                            style={style.inputBox}
                            keyboardType='numeric'
                            placeholder='Lift weight' placeholderTextColor={gray}
                            keyboardAppearance="dark"
                        />
                    </View>
                    <View style={style.formRow}>
                        <Text style={style.inputLabel}>Reps</Text>
                        <TextInput
                            onChangeText={handleChange('reps')}
                            onBlur={handleBlur('reps')}
                            value={values.reps}
                            style={style.inputBox}
                            keyboardType='numeric'
                            placeholder='Repetitions' placeholderTextColor={gray}
                            keyboardAppearance="dark"
                        />
                    </View>
                    <View style={style.formRow}>
                        <Text style={style.inputLabel}>Sets</Text>
                        <TextInput
                            onChangeText={handleChange('sets')}
                            onBlur={handleBlur('sets')}
                            value={values.sets}
                            style={style.inputBox}
                            keyboardType='numeric'
                            placeholder='Sets' placeholderTextColor={gray}
                            keyboardAppearance="dark"
                        />
                    </View>
                    <View style={style.formRow}>
                        <Text style={style.inputLabel}>Rest</Text>
                        <TextInput
                            onChangeText={handleChange('rest')}
                            onBlur={handleBlur('rest')}
                            value={values.rest}
                            style={style.inputBox}
                            keyboardType='numeric'
                            placeholder='Rest time' placeholderTextColor={gray}
                            keyboardAppearance="dark"
                        />
                    </View>
                    {/* <TouchableHighlight //Make this into a component later on.
                        style={[style.buttonSolid, { marginTop: 8 }]}
                        underlayColor={'#922393'}
                        onPress={handleSubmit} //idk wat the fk is going on
                    >
                        <Text style={[style.buttonText, style.white]}>Confirm</Text>
                    </TouchableHighlight> */}
                    {/* <TouchableHighlight style={style.buttonSolid} onPress={pushFirebase}>
                        <Text style={[style.buttonText, style.white]}>Push to Firebase</Text>
                    </TouchableHighlight> */}
                </View>
            )}
        </Formik>
    );
}

export default WorkoutForm;

//Developer Functions
const pushFirebase = () => {
    const ref = firebase.database().ref('realTest')
    console.log("Pushing:")
    console.log(data)
    ref.push(data)
    data = []
    alert("Pushed to firebase!\n'data' array is cleared.");
}

// ==================================== Notes: ====================================
// 
// A single row ideally should look like this: 
// Name [         ] Reps [ ] Sets [ ] Rest [  ] 
// 
// Combined, a single workout will be made out of a series of exercises.
//
// Name [ Bench   ] Reps [ 6]+- Sets [4]+- Rest [150]+- 
// Name [ Rows    ] Reps [ 6]+- Sets [4]+- Rest [120]+- 
// Name [ Curls   ] Reps [ 8]+- Sets [4]+- Rest [ 70]+-
// Name [ Dips    ] Reps [10]+- Sets [3]+- Rest [ 70]+- 
// <- Submit ->
// 
// Might also want to make each row as a component (maybe)
//
// ================== Known bugs and issues: ==================
// [FIXED] The three underlined props of the form. 
// [FIXED] Unable to have in number types.
//
// [!] Able to paste in string on number-only TextInput.
// reps and sets are string instead of number
//
// =============================== To-Do ===============================
// Timer
// 
// 
//