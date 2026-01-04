import {Box, Image} from "@chakra-ui/react";

const ProfilePhoto = ({photoLink}) => (
    <Box 
        borderRadius="full" 
        p="1" 
        border="2px solid" 
        borderColor="brand.500"
        boxShadow="0 0 15px rgba(79, 70, 229, 0.2)"
    >
        <Image
            src={photoLink}
            boxSize={{base: "80px", md: "100px", lg: "120px"}}
            borderRadius="full"
            fit="cover"
            alt="Profile photo"
        />
    </Box>
);

export default ProfilePhoto;